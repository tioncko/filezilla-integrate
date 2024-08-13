using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using filezilla_integrate.Models;
using static filezilla_integrate.Models.XML;

namespace filezilla_integrate
{
    public partial class frmXML : Form
    {
        public frmXML()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dialplan edit = Deserialize(txtLoadXML.Text);
            string dialplan = String.Format("^{0}$", "GNICODELLI_18");
            int destInboundCampaign = 13;
            string nameMailingField = "AD_NOME";
            string announcer = "Rodrigo_Goes";
            string persona = "Caio";
            char genderAnnouncer = 'M';
            bool enable8Personas = true;

            edit.Extensions!.ForEach (
                ex => ex.Conditions!.ForEach (
                    cd => {
                        if (cd.Field!.Contains("destination_number")) cd.Expression = dialplan;
                        if (cd.Action != null) {
                            cd.Action!.ForEach (
                                ac => {
                                    if (ac.Data!.StartsWith("destInboundCampaign="))
                                        ac.Data = $"destInboundCampaign={destInboundCampaign}";
                                    //ac.Data = String.Format("destInboundCampaign={0}, destInboundCampaign);
                                    if (ac.Data!.StartsWith("nameMailingField="))
                                        ac.Data = $"nameMailingField={nameMailingField}";
                                    //ac.Data = String.Format("nameMailingField={0}, nameMailingField);
                                    if (ac.Data!.StartsWith("announcer="))
                                        ac.Data = $"announcer={announcer}";
                                    //ac.Data = String.Format("announcer={0}, announcer);
                                    if (ac.Data!.StartsWith("persona="))
                                        ac.Data = $"persona={persona}";
                                    //ac.Data = String.Format("persona={0}, persona);
                                    if (ac.Data!.StartsWith("genderAnnouncer="))
                                        ac.Data = $"genderAnnouncer={genderAnnouncer.ToString()}";
                                    //ac.Data = String.Format("genderAnnouncer={0}, genderAnnouncer);
                                    if (ac.Data!.StartsWith("enable8Personas="))
                                        ac.Data = $"enable8Personas={enable8Personas.ToString().ToLower()}";
                                    //ac.Data = String.Format("enable8Personas={0}, enable8Personas.ToString().ToLower());
                                }
                            );
                        }
                    })
                );
            string editDialplan = Serialize(edit);
            XDocument doc = XDocument.Parse(editDialplan);

            doc.Descendants("include").Attributes().Remove();
            txtReturnXML.Text = doc.ToString();
        }

        public Dialplan Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialplan));
            StringReader stream = new StringReader(xml);
            return (Dialplan)serializer.Deserialize(stream)!;
        }

        public string Serialize(Dialplan way)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialplan));
            StringWriter stream = new StringWriter();
            serializer.Serialize(stream, way);
            return stream.ToString();
        }
    }
}

#region old_tips
/*
             Dictionary<string, string> dict = new Dictionary<string, string>();

            List<Condition> valor =
            Deserialize(textBox1.Text).Extensions!.SelectMany(x => x.Conditions!.ToList()).ToList();

            foreach (var x in valor) {
                if (x.Action == null)
                {
                    textBox2.Text += "No action" + Environment.NewLine;
                    textBox2.Text += x.Expression + Environment.NewLine;
                }
                else
                    textBox2.Text += x.Action!.SelectMany(x => x.Application!.ToString()).ToString();
            }

            txtLoadXML.Clear();
            XDocument _xmlTextReader = XDocument.Parse(txtLoadXML.Text);
            //List<XElement> elem = _xmlTextReader.Descendants("action").ToList();
            string element = "action", attribute = "data";

            _xmlTextReader.Descendants(element)
                .Select(elem => elem.Attribute(attribute)!.Value)
                .ToList()
                .ForEach(x => txtReturnXML.Text += x + Environment.NewLine);
 */
#endregion