# PizzaPlaceAPI
<h1>Pizza Place API using c#, Entity Framewokrk, .NET 8</h1>
<br/>
<b>Packages</b>
<table>
  <tr>
    <td>
      Microsoft.EntityFrameworkCore - 8.0.6
    </td>
  </tr>
  <tr>
    <td>
      Microsoft.EntityFrameworkCore.SqlServer - 8.0.6
    </td>
  </tr>
  <tr>
    <td>
      Swashbuckle.AspNetCore - 6.4.0
    </td>
  </tr>
</table>
<br/>
1. Ensure that the DefaultConnection is set to your local MS SQL SERVER in the appsettings.json. "DefaultConnection": "Server=COMPUTER_NAME;Database=PizzaPlace;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
<br><br>
2. Please restore the PizzaPlace.bak to your local MS SQL SERVER machine
<br><br>
- Open MS SQL Server Management Studio
<br><br>
- Local MS SQL Server Machine name > Databases - Right Click on Databases and Click "Restore Database"
<br><br>
- Under Source, select "Device" and click the ellipsis button 
<br><br>
- Browse for the PizzaPlace.bak in the PizzaPlaceAPI > Data folder
<br><br>
- Click OK
<br><br>
License MIT

