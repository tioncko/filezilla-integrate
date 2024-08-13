
using static filezilla_integrate.Models.XML;
using System.Xml.Serialization;
using filezilla_integrate.Models;
using System.Xml.Linq;

namespace filezilla_integrate.Auxiliar
{
    internal class HandlerXML
    {
        public FieldDialplan returnFields (string origin) {

            string value = "";

            Dialplan edit = Deserialize(origin);
            FieldDialplan fields = new FieldDialplan();

            edit.Extensions!.ForEach(
                ex => ex.Conditions!.ForEach(
                    cd => {
                        if (cd.Field!.Contains("destination_number")) fields.Dialplan = cd.Expression!.Replace("^", string.Empty).Replace("$", string.Empty);
                        if (cd.Action != null)
                        {
                            cd.Action!.ForEach(
                                ac => {
                                    value = "destInboundCampaign=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.DestInboundCampaign = int.Parse(ac.Data.Substring(value.Length));
                                    value = "nameMailingField=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.NameMailingField = ac.Data.Substring(value.Length);
                                    value = "announcer=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.Announcer = ac.Data.Substring(value.Length);
                                    value = "persona=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.Persona = ac.Data.Substring(value.Length);
                                    value = "genderAnnouncer=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.GenderAnnouncer = Convert.ToChar(ac.Data!.Substring(value.Length));
                                    value = "enable8Personas=".ToLower();
                                    if (ac.Data!.ToLower().StartsWith(value))
                                        fields.Enable8Personas = Convert.ToBoolean(ac.Data!.Substring(value.Length));
                                }
                            );
                        }
                    })
                );
            return fields;
        }

        // if (value.StartsWith("X-customerId: ")) { layout = "X-customerId: "; fields1[0] = value.Substring(layout.Length); }

        public string EditXML(FieldDialplan fields, string origin) {

            Dialplan edit = Deserialize(origin);

            edit.Extensions!.ForEach(
                ex => ex.Conditions!.ForEach(
                    cd => {
                        if (cd.Field!.Contains("destination_number")) cd.Expression = fields.Dialplan;
                        if (cd.Action != null)
                        {
                            cd.Action!.ForEach(
                                ac => {
                                    if (ac.Data!.StartsWith("destInboundCampaign="))
                                        ac.Data = $"destInboundCampaign={fields.DestInboundCampaign}";
                                    //ac.Data = String.Format("destInboundCampaign={0}, destInboundCampaign);
                                    if (ac.Data!.StartsWith("nameMailingField="))
                                        ac.Data = $"nameMailingField={fields.NameMailingField}";
                                    //ac.Data = String.Format("nameMailingField={0}, nameMailingField);
                                    if (ac.Data!.StartsWith("announcer="))
                                        ac.Data = $"announcer={fields.Announcer}";
                                    //ac.Data = String.Format("announcer={0}, announcer);
                                    if (ac.Data!.StartsWith("persona="))
                                        ac.Data = $"persona={fields.Persona}";
                                    //ac.Data = String.Format("persona={0}, persona);
                                    if (ac.Data!.StartsWith("genderAnnouncer="))
                                        ac.Data = $"genderAnnouncer={fields.GenderAnnouncer.ToString()}";
                                    //ac.Data = String.Format("genderAnnouncer={0}, genderAnnouncer);
                                    if (ac.Data!.StartsWith("enable8Personas="))
                                        ac.Data = $"enable8Personas={fields.Enable8Personas.ToString()!.ToLower()}";
                                    //ac.Data = String.Format("enable8Personas={0}, enable8Personas.ToString().ToLower());
                                }
                            );
                        }
                    })
                );
            string editDialplan = Serialize(edit);
            XDocument doc = XDocument.Parse(editDialplan);

            doc.Descendants("include").Attributes().Remove();
            return doc.ToString();
        }

        private Dialplan Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialplan));
            StringReader stream = new StringReader(xml);
            return (Dialplan)serializer.Deserialize(stream)!;
        }

        private string Serialize(Dialplan way)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Dialplan));
            StringWriter stream = new StringWriter();
            serializer.Serialize(stream, way);
            return stream.ToString();
        }
    }
}
