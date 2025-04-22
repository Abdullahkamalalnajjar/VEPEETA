using System.Security.Claims;

namespace Vepeeta.Data.Helpers;

public static class ClaimsStore
{
    public static List<Claim> Claims = new()
    {

     new Claim("Create Project", "false"),
     new Claim("Create SubProject", "false"),
     new Claim("Create Task", "false"),
     new Claim("Create Employee", "false"),
     //new Claim("Edit Showtime", "false"),
     //new Claim("Delete Showtime", "false"),
     //new Claim("Create Reservation", "false"),
     //new Claim("Edit Reservation", "false"),
     //new Claim("Delete Reservation", "false"),
     //new Claim("Create Theater", "false"),
     //new Claim("Edit Theater", "false"),
     //new Claim("Delete Theater", "false"),
    };
}