using System;
using System.ComponentModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security.Cryptography.X509Certificates;
using Perforce.P4;

namespace PowerP4Module
{        
    [Cmdlet(VerbsCommon.Get,"Info")]
    [OutputType(typeof(ServerMetaData))]
    public class GetServerInfo : PSCmdlet
    {
        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string ServerPort { get; set; }
        public PerforceConnection Con { get; set; }
        public Options Opts { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            WriteVerbose("Begin!");
            Con = new PerforceConnection();
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            WriteVerbose("Processing...");
            ServerMetaData p4info = Con.rep.GetServerMetaData(null);

            WriteObject(p4info);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
            WriteVerbose("End!");
            Con.con.Disconnect();
        }
    }

    public class PerforceConnection
    {
        string Uri;
        string user;
        string client;

        public Repository rep {get; set;}
        public Server srv {get; set;}
        public Connection con {get; set;}

        public Options opts {get; set;}

        public PerforceConnection()
        {
            GetConfiguration();
            Connect();
        }
        public PerforceConnection(string client): this()
        {
            GetConfiguration(client);
            Connect();
        }

        public void Connect()
        {
            srv = new Server(new ServerAddress(Uri));
            rep = new Repository(srv);
            con = rep.Connection;
            con.UserName = user;

            opts = new Perforce.P4.Options();
            opts["ProgramName"] = "PowerP4";
            opts["ProgramVersion"] = "0.0.1";
            opts["cwd"] = Directory.GetCurrentDirectory();

            con.Connect(opts);
        }
        public void GetConfiguration()
        {
            // Defaults
            // Config Files
            // Environment Variables
            // Command line arg
            Uri = "localhost:1666";
            user = "perforce";
            client = "ljenkins_DESKTOP-7A5DFEC_development_9972";
        }
        public void GetConfiguration(string client)
        {

        }

    }
}
