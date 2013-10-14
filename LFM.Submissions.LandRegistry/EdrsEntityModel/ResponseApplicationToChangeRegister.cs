using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFM.Submissions.LandRegistry.EdrsEntityModel
{
    public enum ResponseType
    {
        Other = 1,
        Acknowledgement,
        Rejection,
        Result
    }
    
    public class ResponseApplicationToChangeRegister
    {
        public AcknowledgementType AcknowledgementType { get; set; }
        public ResponseType ResponseType { get; set; }
    }
    
    public class AcknowledgementType
    {
        public string UniqueId  { get; set; }        
        public string MessageDescription { get; set; }        
        public string ABR { get; set; }
        public DateTime ExpectedResonse { get; set; }
        public DateTime PriorityDateTime { get; set; }            
    }
    
    public class AttachmentType
    {
        public string Filename { get; set; }
        public string Format { get; set; }
    }

    public class DistrictDetailsType
    {
        public string EntryText { get; set; }
    }

    

    
}
