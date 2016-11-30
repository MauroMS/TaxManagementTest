using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.Util
{
    public class CurrencyHelper
    {
        public static bool ValidateCurrency(string currentyCode)
        {
            System.Globalization.RegionInfo regionInfo = (from culture in System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.InstalledWin32Cultures)
                                                          where culture.Name.Length > 0 && !culture.IsNeutralCulture
                                                          let region = new System.Globalization.RegionInfo(culture.LCID)
                                                          where String.Equals(region.ISOCurrencySymbol, currentyCode, StringComparison.InvariantCultureIgnoreCase)
                                                          select region).FirstOrDefault();

            return regionInfo != null;
        }
    }
}
