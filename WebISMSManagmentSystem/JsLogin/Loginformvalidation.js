
function Loginvalidate() {
    debugger
    var x = $('[id$=TextBox1]').val();;
    
    var pass = $('[id$=TextBox2]').val();;
  
    if (x == "" || x == '') {
        alert("Username  must be filled out");
    }
    if (pass== "" ||pass == '') {
        alert("Passord must be filled out");
    }
}
