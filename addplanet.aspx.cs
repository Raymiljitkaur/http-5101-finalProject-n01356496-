using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP_FINAL_PROJECT
{
    public partial class addplanet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // THIS IS TO ADD PLANET PAGES TO THE PLANET PAGES 
        protected void Add_Planet(object sender, EventArgs e)
        {
           
            PLANETSDB db = new PLANETSDB();


            
             planet new_planet = new planet();
            
            new_planet.SetPtitle(planets_title.Text);
            new_planet.SetPbody(planets_body.Text);
            

            
            db.Addplanet(new_planet);


            Response.Redirect("planetpages.aspx");
        }

    }
}