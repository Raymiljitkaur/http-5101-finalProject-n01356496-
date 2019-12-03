using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_FINAL_PROJECT
{
    public partial class pagenav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PLANETSDB db = new PLANETSDB();
            pageNav(db);
        }
        protected void pageNav(PLANETSDB db)
        {

            pagenav1.InnerHtml = "";

            string searchkey = "";

            // THIS IS THE QUERY WE USE TO ACESS DATA FROM TABLE PLANET

            string query = "select * from planets";

            if (searchkey != "")
            {
                query += " WHERE planets_id like '%" + searchkey + "%' ";
                query += " or planets_title like '%" + searchkey + "%' ";
                query += " or planets_body like '%" + searchkey + "%' ";
            }
            // HERE WE ADD DATA TO THE UL WE DEFINED IN THE IN ASCX PAGE.

            //var db = new PLANETSDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pagenav1.InnerHtml += "<div class=\"listitem\">";
                // THIS IS TO GET PLANET ID FROM THE DATABASE 
                string planet_id = row["planets_id"];
                //planets_result.InnerHtml += "<div class=\"col1\">" + planet_id + "</div>";
                // THIS IS TO GET PLANET TITLE FROM THE DATABASE
                string planet_title = row["planets_title"];
                pagenav1.InnerHtml += "<a href=\"showplanets.aspx?planets_id=" + planet_id + "\">" + planet_title + "</a>";

                //string planet_body = row["planets_body"];
                //planets_result.InnerHtml += "<div class=\"col\">" + planet_body + "</div>";

            



            }
        }
    }
}