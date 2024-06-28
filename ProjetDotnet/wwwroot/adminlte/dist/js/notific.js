document.getElementById("nbtotalmenu").textContent = 0;
document.getElementById("nbtotalhaut").textContent = 0;

var dateauj = new Date();
var datemonth = '';
var dateDay = '';
if ((dateauj.getMonth()+1)<10){
  datemonth = '0'+(dateauj.getMonth()+1);
}else {
  datemonth = (dateauj.getMonth()+1);
}

if (dateauj.getDate()<10){
  dateDay = '0'+(dateauj.getDate());
}else {
  dateDay = (dateauj.getDate());
}
var abc = dateauj.getFullYear() +'-'+ (datemonth) +'-'+ (dateDay);
// Create a request variable and assign a new XMLHttpRequest object to it.
var request = new XMLHttpRequest()
      // Open a new connection, using the GET request on the URL endpoint
      request.open('GET', 'http://192.168.43.96:3000/reclamations', true)
      request.onload = function()
      {
          // Begin accessing JSON data here
          var data = JSON.parse(this.response)
          console.log(data);
          var j = 0;
          data.forEach(i => {
            var tab = i.createdAt.split('T');

             if((i.VUE_RECL=="0")&&(tab[0]==abc)){   
              j = j + 1 ;
             }
          })
          document.getElementById("nbrecla").innerHTML = j;
          var conv = parseInt(document.getElementById("nbtotalmenu").textContent);
          document.getElementById("nbtotalmenu").innerHTML = conv+j;
          var conv2 = parseInt(document.getElementById("nbtotalhaut").textContent);
          document.getElementById("nbtotalhaut").innerHTML = conv2+j;
      }
      // Send request
      request.send()

// Create a request variable and assign a new XMLHttpRequest object to it.
var request = new XMLHttpRequest()
      // Open a new connection, using the GET request on the URL endpoint
      request.open('GET', 'http://192.168.43.96:3000/contacts', true)
      request.onload = function()
      {
          // Begin accessing JSON data here
          var data = JSON.parse(this.response)
          console.log(data);
          var j = 0;
          data.forEach(i => {
            var tab = i.createdAt.split('T');

             if((tab[0]==abc)){   
              j = j + 1 ;
             }
          })
          document.getElementById("nbrecontact").innerHTML = j;
          var conv = parseInt(document.getElementById("nbtotalmenu").textContent);
          document.getElementById("nbtotalmenu").innerHTML = conv+j;
          var conv2 = parseInt(document.getElementById("nbtotalhaut").textContent);
          document.getElementById("nbtotalhaut").innerHTML = conv2+j;
      }
      // Send request
      request.send()

// Create a request variable and assign a new XMLHttpRequest object to it.
var request = new XMLHttpRequest()
      // Open a new connection, using the GET request on the URL endpoint
      request.open('GET', 'http://192.168.43.96:3000/recruteurs', true)
      request.onload = function()
      {
          // Begin accessing JSON data here
          var data = JSON.parse(this.response)
          console.log(data);
          var x = 0;
          data.forEach(i => {
             if(i.VALID_ENT=="0"){   
              x = x + 1 ;
             }
          })
          document.getElementById("nbrecrutEA").innerHTML = x;
          var conv = parseInt(document.getElementById("nbtotalmenu").textContent);
          document.getElementById("nbtotalmenu").innerHTML = conv+x;
          var conv2 = parseInt(document.getElementById("nbtotalhaut").textContent);
          document.getElementById("nbtotalhaut").innerHTML = conv2+x;
      }
      // Send request
      request.send()


  function quitter(){
    localStorage.clear();
    location.replace("login.html");
  }
  function quitterindex(){
    localStorage.clear();
    location.replace("pages/login.html");
  }

  document.getElementById("nvprof").innerHTML = localStorage.getItem("Username_ADM");
  document.getElementById("nvphoto").src = localStorage.getItem("PHOTO_ADM");