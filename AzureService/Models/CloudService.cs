using System.ComponentModel;

namespace AzureService.Models
{
    public class CloudService
    {
        public static String[] InstanceSizeDescriptions
        {
            get
            {
                return new String[] { "Very Small", "Small", "Medium", "Large", "Very Large", "A5", "A6" };
            }
        }

        public static double[] InstanceSizePrices
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80 };
            }
        }

        [DisplayName("No of Instances")]
        public int NoInstances { get; set; }

        [DisplayName("Instance Size")]
        public string  InstanceSize { get; set; }

        public double Cost
        {
            get 
            {
                int size = 0;
                for (int i=0; i<  CloudService.InstanceSizeDescriptions.Length; i++)
                {
                    if (CloudService.InstanceSizeDescriptions[i] == this.InstanceSize)
                    {
                        size = i;
                        break;
                    }
                }

                double hourlyPrice = NoInstances * InstanceSizePrices[size];
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    yearlyPrice = dailyPrice * 366;
                }
                else
                {
                    yearlyPrice = dailyPrice * 365;
                }

                return yearlyPrice;
            }
        }
    }
}
