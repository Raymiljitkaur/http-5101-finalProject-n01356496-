using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_FINAL_PROJECT
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                
                PLANETSDB db = new PLANETSDB();
                ShowPlanetInfo(db);
            }
        }
        // THIS IS THE FUNCTION TO UPDATE THE PLANET WITH THEIR DETAILS
        protected void Update_Planet(object sender, EventArgs e)
        {

           
            PLANETSDB db = new PLANETSDB();

            bool valid = true;
            string planetid = Request.QueryString["planets_id"];
            if (String.IsNullOrEmpty(planetid)) valid = false;
            if (valid)
            {
                planet new_planet = new planet();
                
                new_planet.SetPtitle(planets_title.Text);
                new_planet.SetPbody(planets_body.Text);
               

              
                try
                {
                    db.Updateplanet(Int32.Parse(planetid), new_planet);
                    Response.Redirect("planetpages.aspx?planetid=" + planetid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                planet.InnerHtml = "There was an error updating that planet.";
            }

        }
        // THIS IS TO SHOW THE DETAILS IN THE TEXTBOXES 
        protected void ShowPlanetInfo(PLANETSDB db)
        {

            bool valid = true;
            string planet_id = Request.QueryString["planets_id"];
            if (String.IsNullOrEmpty(planet_id)) valid = false;

           
            if (valid)
            {

                planet planet_record = db.Findplanet(Int32.Parse(planet_id));
               
                planets_title.Text = planet_record.GetPtitle();
                planets_body.Text = planet_record.GetPbody();
              
            }

            if (!valid)
            {
                planet.InnerHtml = "There was an error finding that planet.";
            }
        }
    }
}