using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxEZ.Helpers;
using ProxEZ.Scraper.Modules;
using System.Collections;
using System.Text.RegularExpressions;
using ProxEZ.Checker;
using ProxEZ.Extensions;

namespace ProxEZ.Forms
{
    public partial class frmMain : Form
    {

        private bool proxyChecked;
        private ImageList imageList;
        private List<string> CustomSources;
        public frmMain()
        {
            InitializeComponent();

            imageList = new ImageList();
            imageList.ImageSize = new Size(16, 11);
            CustomSources = new List<string>();
            //lvwColumnSorter = new Helpers.ListViewItemComparer();
            //lvProxies.ListViewItemSorter = lvwColumnSorter;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lvProxies.SmallImageList = imageList;
           // CountryInfo.GetCountryInfo("84.39.40.62");
        }




        private async void btnScrape_Click(object sender, EventArgs e)
        {
            btnScrape.Enabled = false;
            var hosts = new List<string>();
            if (rbCustom.Checked)
            {
                if (CustomSources.Count == 0)
                {
                    MessageBox.Show("You have selected custom source list. Please load some before scraping.", "Form Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                hosts.Clear();
                hosts.AddRange(CustomSources.ToArray());
            }
            // hosts.Add("https://orca.tech/?action=real-time-proxy-list");
            //hosts.Add("http://free-proxy-list.net/anonymous-proxy.html");
           // hosts.Add("http://www.us-proxy.org/");
           // hosts.Add("www.sslproxies.org");
            //hosts.Add("http://irc-proxies24.blogspot.com/2016/08/26-08-16-irc-proxy-servers-900_26.html");
          //  hosts.Add("http://www.samair.ru/proxy/");
            //hosts.Add("https://www.hide-my-ip.com/proxylist.shtml");
            //hosts.Add("http://fineproxy.org/eng/?p=6");
            //hosts.Add("http://www.blackhatworld.com/seo/new-fresh-big-proxy-lists-worldwide-usa-and-elite-proxies-updated-daily.753956/page-21");
            //hosts.Add("https://us-proxy-server.blogspot.com/");
            //  hosts.Add("http://txt.proxyspy.net/proxy.txt");
            //hosts.Add("http://txt.proxyspy.net/proxy.txt");
            // hosts.Add("http://proxyrox.com");
            //hosts.Add("https://nordvpn.com/wp-admin/admin-ajax.php?searchParameters[0][name]=proxy-country&searchParameters[0][value]=&searchParameters[1][name]=proxy-ports&searchParameters[1][value]=&offset=25&limit=10000&action=getProxies");
            lvProxies.BeginUpdate();
            // BLOGSPOT
            //hosts.Add("http://proxyserverlist-24.blogspot.com/");
           //hosts.Add("http://sslproxies24.blogspot.ro");
           // hosts.Add("http://sslproxies24.blogspot.ro");

            bool checkLimit = cbLimit.Checked;
            var numLimit = (int)this.numLimit.Value;
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 10 };
            var _Scraper = new Scraper.Scraper();

            Hashtable hash = new Hashtable();


            Stopwatch s = new Stopwatch();
            s.Start();
            await Task.Run(() =>
            {
                Parallel.ForEach(hosts, options, (item) =>
                {
                    try
                    {
                        if (checkLimit && hash.Count >= numLimit)
                            return;
                        if (!item.StartsWith("http://") && !item.StartsWith("https://"))
                            item = "http://" + item;
                        string html = HTTP.DoWebRequest(item);
                        if (string.IsNullOrEmpty(html)) return;
                        List<Proxy> proxies = _Scraper.Scrape(item, html);
                        if (proxies == null) return;
                        Parallel.ForEach(proxies, options, (proxy) =>
                        {
                            if (proxy == null) return;
                            
                            if (checkLimit && hash.Count >= numLimit)
                                return;
                            lock (hash)
                            {
                                if (!hash.Contains(proxy.Proxy_))
                                    hash.Add(proxy.Proxy_, proxy);
                            }
                            
                        });
                    }
                    catch { }
                });
            });

            foreach (DictionaryEntry element in hash)
            {
                if (checkLimit && lvProxies.Items.Count >= numLimit)
                    break;
                Proxy proxy = (Proxy)(element.Value);

                Invoke(new MethodInvoker(() =>
                {

                    ListViewItem i = new ListViewItem((lvProxies.Items.Count + 1).ToString());
                    var countryCode = CountryInfo.GetCode(proxy.Country);
                    if (!imageList.Images.Keys.Contains(countryCode))
                        imageList.Images.Add(countryCode, Image.FromFile(@"Flags\" + countryCode + ".png"));
                    i.ImageKey = countryCode;

    
                    // i.UseItemStyleForSubItems = false;
                    i.SubItems.Add(proxy.Proxy_);
                    i.SubItems.Add(proxy.Anonymity);
                    i.SubItems.Add(proxy.Country);
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    lvProxies.Items.Add(i);
                }));
            }

            s.Stop();
            lvProxies.EndUpdate();
            MessageBox.Show("Done!\r\nTime Elapsed: " + s.Elapsed);
            btnScrape.Enabled = true;
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            if (lvProxies.Items.Count <= 0) return;

            // Validity checks
            if (cbSSL.Checked)
            {
                if (!tbSSL.Text.StartsWith("https://"))
                {
                    MessageBox.Show("Please enter a valid HTTPS url to test!", "Form Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    var url = new Uri(tbSSL.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid HTTPS url to test!", "Form Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (cbCustom.Checked)
            {
                //if (!tbCustom.Text.StartsWith("https://"))
                //{
                //    MessageBox.Show("Please enter a valid HTTPS url to test!", "Form Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                try
                {
                    var url = new Uri(tbCustom.Text);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid custom url to test!", "Form Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //UpdateStatus("Checking proxies...");
            btnCheck.Enabled = false;
            proxyChecked = false;
            //   cmsRotator.Enabled = false;
            //  btnRotate.Enabled = false;


            var proxies = new List<ListViewItem>();
            foreach (ListViewItem item in lvProxies.Items)
                proxies.Add(item);

            var options = new ParallelOptions { MaxDegreeOfParallelism = 50 };

            await Task.Run(() =>
            {

                try
                {
                    Parallel.ForEach(proxies, options, proxy =>
                    {
                        string[] prox = proxy.SubItems[1].Text.Split(new[] { ":" }, StringSplitOptions.None);
                        ProxyResult r = Checker.Checker.Check(
                            new WebProxy(prox[0], int.Parse(prox[1])),
                            int.Parse(prox[1]),
                            cbSSL.Checked ? tbSSL.Text : "",
                            cbCustom.Checked ? tbCustom.Text : ""
                        );

                        Invoke(new MethodInvoker(() =>
                        {
                            if (!r.Working || r.Speed > 10000)
                                //if (dead || (cbSlow.Checked && speed > 10000))
                                lvProxies.Items[proxy.Index].BackColor = Color.FromArgb(255, 207, 206);
                            else
                            {

                                lvProxies.Items[proxy.Index].SubItems[2].Text = r.Anonymity;
                                lvProxies.Items[proxy.Index].SubItems[3].Text = r.CountryInfo[1];

                                var countryCode = CountryInfo.GetCode(r.CountryInfo[1]);

                                if (!imageList.Images.Keys.Contains(countryCode))
                                    imageList.Images.Add(countryCode, Image.FromFile(@"Flags\" + countryCode + ".png"));
                                lvProxies.Items[proxy.Index].ImageKey = countryCode;

                                lvProxies.Items[proxy.Index].SubItems[4].Text = r.Speed + " ms";
                                if (cbSSL.Checked)
                                {
                                    lvProxies.Items[proxy.Index].SubItems[5].Text = r.SSL ? "Yes" : "No";
                                    lvProxies.Items[proxy.Index].SubItems[5].ForeColor = r.SSL ? Color.DarkGreen : Color.Red;
                                }
                                else
                                    lvProxies.Items[proxy.Index].SubItems[5].Text = "N\\A";

                                if (cbCustom.Checked)
                                {
                                    lvProxies.Items[proxy.Index].SubItems[6].Text = r.Custom ? "Yes" : "No";
                                    lvProxies.Items[proxy.Index].SubItems[6].ForeColor = r.Custom ? Color.DarkGreen : Color.Red;
                                }
                                else
                                    lvProxies.Items[proxy.Index].SubItems[6].Text = "N\\A";

                                lvProxies.Items[proxy.Index].BackColor = Color.FromArgb(202, 255, 202);

                            }
                        }));
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            });


            //lProxyCount.Text = "Loaded Proxies: " + lvProxies.Items.Count;
            //UpdateStatus("Finished checking proxies.");
            btnCheck.Enabled = true;
            proxyChecked = true;
            //cmsRotator.Enabled = true;
            //btnRotate.Enabled = true;
        }



        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvProxies.SelectedItems.Count == 0) return;
            var text = "";
            foreach (ListViewItem item in lvProxies.SelectedItems)
                text += item.SubItems[1].Text + Environment.NewLine;

            Clipboard.SetText(text);
        }

        private void importProxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importProxiesFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Clipboard.GetText()))
            {
                MessageBox.Show("Your clipboard appears to be empty!", "ProxEZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Generic tmp = new Generic();
            var prox = tmp.Scrape(Clipboard.GetText());
            if (prox.Count == 0)
            {
                MessageBox.Show("There were no proxies found in your clipboard!", "ProxEZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (Proxy p in prox)
            {
                ListViewItem i = new ListViewItem(lvProxies.Items.Count.ToString());
                //i.Tag = p
                i.SubItems.Add(p.Proxy_);
                i.SubItems.Add(p.Anonymity);
                i.SubItems.Add(p.Country);
                i.SubItems.Add("");
                i.SubItems.Add("");
                lvProxies.Items.Add(i);
            }
        }

        private void lvProxies_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //lvProxies.ListViewItemSorter = new ListViewItemComparer(e.Column);
            //lvProxies.Sort();
            //// TODO: Maybe fix order column
        }


        private void removeAllProxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rm = MessageBox.Show("Are you sure you want to clear all proxies?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rm != DialogResult.Yes) return;
            lvProxies.BeginUpdate();
            lvProxies.Items.Clear();
            lvProxies.EndUpdate();
        }

        //private void UpdateIndices()
        //{
        //    for (int i = 0; i < lvProxies.Items.Count; i++)
        //        lvProxies.Items[i].SubItems[0].Text = i.ToString();
        //}

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                
                if (ofd.ShowDialog() != DialogResult.OK) return;

                foreach(var source in File.ReadAllLines(ofd.FileName))
                    if(!CustomSources.Contains(source))
                        CustomSources.Add(source);
                MessageBox.Show( CustomSources.Count + " custom sources successfully loaded!", "Load Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text File | *.txt";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (var tw = new StreamWriter(sfd.FileName))
                {
                    foreach (ListViewItem item in lvProxies.Items)
                    {
                        tw.WriteLine(item.SubItems[1].Text);
                    }
                }
                MessageBox.Show("Proxies successfully saved to:\r\n" + sfd.FileName, "Export Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveC_Click(object sender, EventArgs e)
        {
            if (lvProxies.Items.Count == 0 || !proxyChecked)
            {
                MessageBox.Show("Make sure you have scraped and checked some proxies first!", "Hold up!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text File | *.txt";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                using (var tw = new StreamWriter(sfd.FileName))
                {
                    foreach (ListViewItem item in lvProxies.Items)
                    {
                        if (item.BackColor == Color.FromArgb(255, 207, 206))
                            continue;

                        var anon = item.SubItems[2].Text;
                        var speed = item.SubItems[4].Text;
                        var ssl = item.SubItems[5].Text == "Yes";
                        var custom = item.SubItems[6].Text == "Yes";

                        // Anonymity
                        if (cbHighEliteCheck.Checked || cbEliteCheck.Checked || cbAnonCheck.Checked || cbTransCheck.Checked)
                        {
                            switch (anon)
                            {

                                case "High Elite":
                                    {
                                        if (!cbHighEliteCheck.Checked) continue;
                                        break;
                                    }
                                case "Elite":
                                    {
                                        if (!cbEliteCheck.Checked) continue;
                                        break;
                                    }
                                case "Anonymous":
                                    {
                                        if (!cbAnonCheck.Checked) continue;
                                        break;
                                    }
                                case "Transparent":
                                    {
                                        if (!cbTransCheck.Checked) continue;
                                        break;
                                    }
                            }
                        }
                        // Ping
                        if (cbPingCheck.Checked && int.Parse(speed.Replace(" ms", "")) > (int)numPing.Value)
                            continue;

                        // SSL
                        if (cbSSLCheck.Checked && !ssl) continue;

                        // Custom URL
                        if (cbCustomURLCheck.Checked && !custom) continue;


                        // All passed, save
                        tw.WriteLine(item.SubItems[1].Text);
                    }
                }
                MessageBox.Show("Proxies successfully saved to:\r\n" + sfd.FileName, "Export Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettings().Show();
        }
    }

}
