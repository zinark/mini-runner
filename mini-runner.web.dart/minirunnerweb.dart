#import('dart:html');
#import('dart:json');

class Job
{
  String Name;
  
  Job () {}

  void fromJson (String json){
    Map<String, Object> map = JSON.parse (json);
    Name = map["Name"];
  }
}
class webApp {

  webApp() {
  }

  void run() {
    write("Hello World!");
  }

  void write(String message) {
    // the HTML library defines a global "document" variable
    document.query('#status').innerHTML = message;
    String url = 'http://localhost:8542/Home/Jobs';
    
    XMLHttpRequest req = new XMLHttpRequest ();
    req.open('GET', url, true);
    req.on.load.add((res) {
      Map<String, String> results = JSON.parse(req.responseText);
      
      List<Job> jobs = new List<Job> (); 
      
      results.forEach((x,y) {
        print (x);
        print (y);
        // Job j = new Job ();
        // j.fromJson(y);
        // jobs.add(j);
      });
      document.query("#list").innerHTML = req.responseText;
    });
    
    // req.setRequestHeader('Content-type', 'application/json');
    req.send();
  }
}

void main() {
  new webApp().run();
}
