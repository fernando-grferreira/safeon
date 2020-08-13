using System;

namespace Safeon.Web.Models.Form.Occurrence
{
    public class OccurrenceForm
    {
        public OccurrenceForm()
        {
            InformationForm = new InformationForm();
            OccurrenceLogForm = new OccurrenceLogForm();
            ActuationForm = new ActuationForm();
            ChecklistForm = new ChecklistForm();
            TrackableObjectForm = new TrackableObjectForm();
        }

        public int OccurrenceTypeId { get; set; }
        public string OccurrenceTypeName { get; set; }
        public int OccurrenceStatusId { get; set; }
        public string OccurrenceStatusName { get; set; }
        public DateTime DateTime { get; set; }

        public InformationForm InformationForm { get; set; }
        public OccurrenceLogForm OccurrenceLogForm { get; set; }
        public ActuationForm ActuationForm { get; set; }
        public ChecklistForm ChecklistForm { get; set; }
        public TrackableObjectForm TrackableObjectForm  { get;set;}
    }
}