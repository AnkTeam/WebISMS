
function Loginvalidate() {
    debugger
    var x = $('[id$=TxtUsername]').val();;
    
    var pass = $('[id$=txtpassword]').val();;
  
    if (x == "" || x == '') {
        alert("Username  must be filled out");
    }
    if (pass== "" ||pass == '') {
        alert("Passord must be filled out");
    }
}

function IncurrectPassword()
{
    alert("wrong password");
}



