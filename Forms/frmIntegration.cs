using filezilla_integrate.Models;

namespace filezilla_integrate
{
    public partial class frmIntegration : Form
    {
        private FilezillaIntegrate _filezillaIntegrate;
        private readonly string remoteFile = "/usr/local/olos_vpl/conf/dialplan/public/";

        public frmIntegration()
        {
            InitializeComponent();

            Credentials credentials = new Credentials
            {
                Sftp = "10.15.15.195",  //txtSftp.Text,
                User = "olos",          //txtUser.Text,
                Pass = "skyl!n&GTR",    //txtPass.Text;
                Port = 22               //int.Parse(txtPort.Text);
            };
            hideObjects(false);
            _filezillaIntegrate = new FilezillaIntegrate(credentials);
        }

        #region Events
        private void txtUpload_TextChanged(object sender, EventArgs e)
        {
            btnUpload.Enabled = (txtUpload.Text.EndsWith("\\")) ? true : false;
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            btnDialplan.Enabled = (txtFile.Text.Contains(".xml")) ? true : false;
        }

        private void txtListCommand_TextChanged(object sender, EventArgs e)
        {
            btnListAll.Enabled = (txtListCommand.Text.EndsWith("/")) ? true : false;
        }
        #endregion

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                _filezillaIntegrate.SftpConnect();
                _filezillaIntegrate.sshConnect();
                txtStatus.Text = "Connected to " + _filezillaIntegrate._credentials.Sftp;
                hideObjects(true);
            }
            catch (Exception ex) { txtStatus.Text = ex.Message; }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            string validBar = txtUpload.Text.Substring(Path.GetDirectoryName(txtUpload.Text)!.Length + 1, 1);
            string localFile = validBar != "\\" ? txtUpload.Text + "\\" : txtUpload.Text;
            //string remoteFile = "/usr/local/olos_vpl/conf/dialplan/public/";//"/home/olos/Workspace/";
            bool integrate = _filezillaIntegrate.SftpUpload(localFile, remoteFile, txtFile.Text);

            txtStatus.Text = (integrate) ? "File uploaded" : "File not found";
            btnReload.Visible = (integrate) ? true : false;
            txtReload.Visible = (integrate) ? true : false;
            btnUpload.Enabled = false;
            //quando clicar no upload, configurar para mostrar o botão de reload e listall
        }

        #region Drag and Drop
        private void hideObjects(bool valid)
        {
            txtStatus.ReadOnly = true;
            txtListAll.ReadOnly = true;

            if (valid)
            {
                txtFile.Visible = true;
                txtUpload.Visible = true;
                lblUpload.Visible = true;
                btnUpload.Visible = true;
                btnDialplan.Visible = true;

                txtListAll.Enabled = true;
                btnListAll.Enabled = true;

                txtSftp.Enabled = false;
                txtUser.Enabled = false;
                txtPass.Enabled = false;
                txtPort.Enabled = false;
                btnEnter.Enabled = false;
            }
            else
            {
                txtFile.Visible = false;
                txtUpload.Visible = false;
                lblUpload.Visible = false;
                btnUpload.Visible = false;
                btnUpload.Enabled = false;
                btnReload.Visible = false;
                txtReload.Visible = false;
                btnDialplan.Visible = false;
                btnDialplan.Enabled = false;
                txtListAll.Enabled = false;
                btnListAll.Enabled = false;
            }
        }
        #endregion

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
            txtStatus.Text = _filezillaIntegrate.sshExecute(txtReload.Text);
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            foreach (string txt in _filezillaIntegrate.sshListAll(txtListCommand.Text))
            {
                txtListAll.Text += txt;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _filezillaIntegrate.Disconnect();
            Environment.Exit(0);
        }

        private void btnDialplan_Click(object sender, EventArgs e)
        {
            frmDialplan dialplan = new frmDialplan(_filezillaIntegrate, txtFile.Text, remoteFile);
            dialplan.ShowDialog();

            if (dialplan.reload)
            {
                btnReload.Enabled = true;
                btnReload.Visible = true;

                txtReload.Visible = true;
            }
        }
    }
}

#region old_code
/*
         private void btnReload_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient(
                _filezillaIntegrate._credentials.Sftp,
                _filezillaIntegrate._credentials.Port,
                _filezillaIntegrate._credentials.User,
                _filezillaIntegrate._credentials.Pass
                );
            sshClient.Connect();

            var stream = sshClient.CreateShellStream("vt-100", 80, 24, 800, 600, 1024);
            //            stream.WriteLine("olos_vpl_cli -x \"reloadxml\"");
            stream.WriteLine(txtReload.Text);

            List<string> resultExec = new List<string>();
            string line;
            while ((line = stream.ReadLine(TimeSpan.FromSeconds(2))!) != null)
            {
                resultExec.Add(line + Environment.NewLine);
                // if a termination pattern is known, check it here and break to exit immediately
            }

            foreach (string txt in resultExec)
            {
                if (txt.ToUpper().Contains("SUCCESS")) txtStatus.Text = txt.ToUpper();
            }

            stream.Close();
            sshClient.Disconnect();
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            SshClient sshClient = new SshClient(
                _filezillaIntegrate._credentials.Sftp,
                _filezillaIntegrate._credentials.Port,
                _filezillaIntegrate._credentials.User,
                _filezillaIntegrate._credentials.Pass
                );
            sshClient.Connect();

            string command = "cd /usr/local/olos_vpl/conf/dialplan/public && ls -lh"; //home/olos/Workspace && ls -lh";
            
            SshCommand sshCommand = sshClient.RunCommand(command);
            var result = sshCommand.Execute().Split("\n");
            
            foreach (string txt in result)
            {
                txtListAll.Text += txt + Environment.NewLine;
            }
            sshClient.Disconnect();
        }
 */
#endregion