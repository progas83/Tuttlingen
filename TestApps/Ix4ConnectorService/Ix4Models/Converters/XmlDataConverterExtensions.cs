using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ix4Models.Converters
{
    public static class XmlDataConverterExtensions
    {
        public static LICSRequest ConvertTo(this OutputPayLoad navisionOutputPayload)
        {
            LICSRequest licsRequest = new LICSRequest();
            licsRequest.ClientId = 1000001;

            List<LICSRequestOrder> listLicsRequestOrder = new List<LICSRequestOrder>();
          
          //  navisionOutputPayload.OrderHeader
           // licsRequest.OrderImport
            foreach(OutputPayLoadOutputPosition outputPosition in navisionOutputPayload.Positions)
            {
                LICSRequestOrder requestOrder = new LICSRequestOrder();
                requestOrder.ShipmentDate = DateTime.Parse(navisionOutputPayload.OrderHeader.Date); // STRONG TYPIZATION!!!!
            }
            return licsRequest;
        }

        public static LICSRequestOrderPosition ConvertTo(this OutputPayLoadOutputPosition navisionOutputPosition)
        {
            LICSRequestOrderPosition orderPosition = new LICSRequestOrderPosition();
            orderPosition.ArticleNo = navisionOutputPosition.ArticleNumber;
            orderPosition.TargetQuantity =Convert.ToDouble(navisionOutputPosition.VPECount);
            //navisionOutputPosition.ArticleRowNumber;
            //navisionOutputPosition.AttachedToLineNo;
            //navisionOutputPosition.BaseUnitQuantity;
            //navisionOutputPosition.Description;
            //navisionOutputPosition.Description2;
            //navisionOutputPosition.VPECode;
            //navisionOutputPosition.Warehouse;


                return orderPosition;
        }

        public static LICSRequestOrderRecipient ConvertTo(this OutputPayLoadOrderHeader navisionOrderHeader)
        {
            LICSRequestOrderRecipient orderRecipient = new LICSRequestOrderRecipient();
            orderRecipient.Name = navisionOrderHeader.CustomerName;
            orderRecipient.AdditionalName = (string)navisionOrderHeader.CustomerName2;
            orderRecipient.Street = navisionOrderHeader.CustomerStreet;
            orderRecipient.ZIPCode =navisionOrderHeader.CustomerZIP.ToString();
            orderRecipient.City = navisionOrderHeader.CustomerTown;

            return orderRecipient;
        }
    }
}
