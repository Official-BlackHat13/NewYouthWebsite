using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;



/// <summary>
/// Summary description for General
/// </summary>
public class General
{
    #region LocalConnection
    public String ConnectionString()
    {
         // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_YouthMain;User Id=sa;Password=Youth321;MultipleActiveResultSets=True; Pooling=false;";
        //return "Data Source=DESKTOP-56VNM3M\\SQLSERVER;Initial Catalog=ypaweb;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
        // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_YouthMain;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";      
        //return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=moyakwt_YouthMain;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
       // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=ypaweb;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";  
     // return "Data Source=tcp:192.168.13.7,49480;Initial Catalog=ypaweb;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";
       // return "Data Source=SIJILAPARAMAN-W;Initial Catalog=moyakwt_YouthMain;User Id=top;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";

        return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=moyakwt_YouthMain;User Id=ypaAdmin;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
        
    }

    public String ConnectionString2()  //Initiatives
    {
          // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_youthInitiatives;User Id=sa;Password=Youth321;MultipleActiveResultSets=True; Pooling=false;";
        //return "Data Source=DESKTOP-56VNM3M;Initial Catalog=youthInitiatives;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
       // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=moyakwt_YouthInitiatives;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
        //return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=MYA_Professional_Initiative;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
        //return "Data Source=SIJILAPARAMAN-W;Initial Catalog=moyakwt_YouthInitiatives;User Id=top;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
        return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=moyakwt_YouthInitiatives;User Id=ypaAdmin;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
  }

    //public String ConnectionStringMYAPI()  //Professional Initiatives
    //{
    //    //  return "Data Source=DESKTOP-56VNM3M;Initial Catalog=moyakwt_YPI;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=MYA_Professional_Initiative;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
    //}

    //public String YPIConnectionString()  
    //{
    //     // return "Data Source=DESKTOP-56VNM3M;Initial Catalog=moyakwt_YPI;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=moyakwt_YPI;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
    //}
    public String ConnectionStringHR()
    {
        //return "Data Source=.\\sqlexpress;Initial Catalog=youth_HR;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
          return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthHR;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";

    }
    public String LocalConnectionString()
    {
         return "Data Source=.\\SQLEXPRESS;Initial Catalog=youth_HR;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
      // return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthHR;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";

    }

    public String HRADMINConnectionString()
    {
         return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=youth_HR_Admin;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
         // return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youth_HR_Admin;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";

    }

    public String myConnectionString()
    {
      //  return "Data Source=DESKTOP-56VNM3M\\SQLEXPRESS;Initial Catalog=moyakwt_YouthCpanel;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
      // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_youthHR;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
      // return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=moyakwt_YouthCpanel;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
      //  return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=moyakwt_YouthMain;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
      //  return "Data Source=SIJILAPARAMAN-W;Initial Catalog=moyakwt_YouthCpanel;User Id=top;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
        return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=moyakwt_YouthCpanel;User Id=ypaAdmin;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
    }

    public String ServerConnectionString()
    {
       //return "Data Source=192.168.14.16;Initial Catalog=youthq8_youthHR;User Id=sa;Password=tiger;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";
       return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=youthq8_YouthMain;User Id=MYAcontrol;Password=IT@helpmoya;MultipleActiveResultSets=True; Pooling=false;";

    }
    public String YPIConnectionString()  //Professional Initiatives
    {
        //  return "Data Source=DESKTOP-56VNM3M;Initial Catalog=moyakwt_YPI;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
        return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=moyakwt_YPI;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
    }
    public String ConnectionStringMYAPI()  //Professional Initiatives
    {
        //  return "Data Source=DESKTOP-56VNM3M;Initial Catalog=moyakwt_YPI;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
        return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=MYA_Professional_Initiative;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True; Pooling=false;";
    }

    public String ConnectionString1()
    {
        // return "Data Source=tcp:192.168.13.7,49480;Initial Catalog=moyakwt_YouthMain;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";
       return "Data Source=tcp:192.168.13.7,49480;Initial Catalog=moyakwt_YouthMain;User Id=Moya@kwtbU$er;Password=pRU=4EkWt-e3et;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";

    }
    public String YPA()  //YPA
    {
        // return "Data Source=IT-LOCALSERVER\\SQLSERVER;Initial Catalog=YPA;User Id=ypaAdmin;Password=123456Top;MultipleActiveResultSets=True; Pooling=false;";
        return "Data Source=tcp:youthsql.database.windows.net,1433;Initial Catalog=DB-MainWebSite;User Id=youthsqluser;Password=$QLdbLog!n@Azur3$QL;MultipleActiveResultSets=True; Pooling=false;Connection Timeout=120;Persist Security Info=False;";
        //

      //  return "Data Source=tcp:websiteypa.database.windows.net,1433;Initial Catalog=DB-MainWebSite;User Id=youthsqluser;Password=$QLdbLog!n@Azur3$QL;MultipleActiveResultSets=True; Pooling=false;Connection Timeout=120;Persist Security Info=False;";
       
       
    }
    #endregion


    #region ServerConnection
    //public String ConnectionString()
    //{
    // //  return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_YouthMain;User Id=sa;Password=Youth321;MultipleActiveResultSets=True; Pooling=false;";
    //    //return "Data Source=MOYA-003\\SQLEXPRESS;Initial Catalog=youthq8_YouthMain;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_YouthMain;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
	
    //}

    //public String ConnectionString2()
    //{
    //    //  return "Data Source=192.168.13.7\\SQLSERVER;Initial Catalog=youthq8_YouthMain;User Id=sa;Password=Youth321;MultipleActiveResultSets=True; Pooling=false;";
    //  //  return "Data Source=MOYA-003\\SQLEXPRESS;Initial Catalog=youthInitiatives;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthInitiatives;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
         
    //}
    //public String ConnectionStringHR()
    //{
    //   // return "Data Source=.\\sqlexpress;Initial Catalog=youth_HR;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthHR;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    
    //}
    //public String LocalConnectionString()
    //{
    //   // return "Data Source=.\\SQLEXPRESS;Initial Catalog=youth_HR;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthHR;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
   
    //}

    //public String HRADMINConnectionString()
    //{
    //  // return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=youth_HR_Admin;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youth_HR_Admin;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    
    //}

    //public String myConnectionString()
    //{
    //    //return "Data Source=.\\sqlexpress;Initial Catalog=youth_HR;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_youthHR;User Id=MYAcontrol;Password=IT@helpmoya;integrated security=True;MultipleActiveResultSets=True; Pooling=false;";
    
    //}

    //public String ServerConnectionString()
    //{
    //    // return "Data Source=192.168.14.16;Initial Catalog=youthq8_youthHR;User Id=sa;Password=tiger;MultipleActiveResultSets=True;Pooling=false;Connection Timeout=120;Persist Security Info=False;";
    //    return "Data Source=tcp:10.200.200.59,49480;Initial Catalog=youthq8_YouthMain;User Id=MYAcontrol;Password=IT@helpmoya;MultipleActiveResultSets=True; Pooling=false;";

    //}
    #endregion


}
