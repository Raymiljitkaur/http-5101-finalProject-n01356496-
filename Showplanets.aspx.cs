using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_FINAL_PROJECT
{
    public partial class Showplanets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              PLANETSDB db = new PLANETSDB();
               
                ShowplanetInfo(db);
               
               
        }
        // THIS FUNCTION IS TO SHOW THE PLANET INFORMATION WHICH IS STORED BY ADD PAGE .
        // HERE WE TAKING VALUES FROM DATABASE FOR PLANET TITLE AND PLANET DETAILS.
        protected void ShowplanetInfo(PLANETSDB db)
        {
           
            bool valid = true;
            string planetsid = Request.QueryString["planets_id"];
            if (String.IsNullOrEmpty(planetsid)) valid = false;

          
            if (valid)
            {

                planet planets_record = db.Findplanet(Int32.Parse(planetsid));
                planets_title.InnerHtml += planets_record.GetPtitle();
                planets_body.InnerHtml += planets_record.GetPbody();
               
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                planet.InnerHtml = "There was an error finding that planet.";
            }
        }
        // ALSO ON THIS PAGE I HAVE ADDED A FUNCTIONALITY TO DELETE THE PLANET IF ITS NOT NEEDED ANYMORE.
        protected void Delete_planet(object sender, EventArgs e)
        {
            bool valid = true;
            string planetid = Request.QueryString["planets_id"];
            if (String.IsNullOrEmpty(planetid)) valid = false;

            PLANETSDB db = new PLANETSDB ();

           //HERE WE ARE REDIRECTING IT TO THE MAIN PAGE.
            if (valid)
            {
                db.Delete_planet(Int32.Parse(planetid));
                Response.Redirect("planetpages.aspx");
            }
        }
    }

}