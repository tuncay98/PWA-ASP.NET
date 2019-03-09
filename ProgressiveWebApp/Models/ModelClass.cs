using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgressiveWebApp.Models
{
    public class Renewals
    {
        public int days7 { get; set; }
        public int days6 { get; set; }
        public int days5 { get; set; }
        public int days4 { get; set; }
        public int days3 { get; set; }
        public int days2 { get; set; }
        public int days1 { get; set; }
        public int days0 { get; set; }
    }

    public class Minutes
    {
        public int days7 { get; set; }
        public int days6 { get; set; }
        public int days5 { get; set; }
        public int days4 { get; set; }
        public int days3 { get; set; }
        public int days2 { get; set; }
        public int days1 { get; set; }
        public int days0 { get; set; }
    }

    public class Cost
    {
        public int days7 { get; set; }
        public int days6 { get; set; }
        public int days5 { get; set; }
        public int days4 { get; set; }
        public int days3 { get; set; }
        public int days2 { get; set; }
        public int days1 { get; set; }
        public int days0 { get; set; }
    }

    public class Calls
    {
        public int days7 { get; set; }
        public int days6 { get; set; }
        public int days5 { get; set; }
        public int days4 { get; set; }
        public int days3 { get; set; }
        public int days2 { get; set; }
        public int days1 { get; set; }
        public int days0 { get; set; }
    }

    public class Stats
    {
        public object top_call_source { get; set; }
        public Renewals renewals { get; set; }
        public Minutes minutes { get; set; }
        public Cost cost { get; set; }
        public Calls calls { get; set; }
        public int tracking_numbers { get; set; }
        public int renewed_numbers { get; set; }
    }

    public class Account
    {
        public int id { get; set; }
        public string name { get; set; }
        public string user_role { get; set; }
        public string status { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public object canceled { get; set; }
        public Stats stats { get; set; }
        public string voice_menus_url { get; set; }
        public string numbers_url { get; set; }
        public string receiving_numbers_url { get; set; }
        public string sources_url { get; set; }
        public string users_url { get; set; }
        public string webhooks_url { get; set; }
        public string calls_url { get; set; }
        public string queues_url { get; set; }
        public string schedules_url { get; set; }
        public string geo_routes_url { get; set; }
        public string url { get; set; }
    }

    public class Obj
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total_entries { get; set; }
        public int total_pages { get; set; }
        public object next_page { get; set; }
        public object previous_page { get; set; }
        public List<Account> accounts { get; set; }
        public int renewed_numbers { get; set; }
    }

    public class Number
    {
        public List<ListNumber> numbers { get; set; }
    }

    public class ListNumber
    {
        public string number { get; set; }
    }

    public class CallsAndAccount
    {
        public Account account { get; set; }
        public CallsList callsList { get; set; }
    }

    public class CallsList
    {
        public List<CallDetail> calls { get; set; }
    }

    public class CallDetail
    {
        public string tracking_number { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string source { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string called_at { get; set; }
        public string tracking_label { get; set; }
        public string business_number { get; set; }
        public string status { get; set; }
        public string call_status { get; set; }
        public string audio { get; set; }
        public string account_id { get; set; }
        public string contact_number { get; set; }
        public string id { get; set; }
        public string talk_time { get; set; }
    }
}