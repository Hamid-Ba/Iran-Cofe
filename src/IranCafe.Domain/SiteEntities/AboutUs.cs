using Framework.Domain;

namespace IranCafe.Domain.SiteEntities
{
    public class Setting : EntityBase
    {
        public string? Mobiles { get; private set; }
        public string? Emails { get; private set; }
        public string? Text { get; private set; }
        public string? SummaryText { get; private set; }

        public Setting(string? mobiles, string? emails, string? text, string? summaryText)
        {
            Mobiles = mobiles;
            Emails = emails;
            Text = text;
            SummaryText = summaryText;
        }

        public void Edit(string? mobiles, string? emails, string? text, string? summaryText)
        {
            Mobiles = mobiles;
            Emails = emails;
            Text = text;
            SummaryText = summaryText;
        }
    }
}