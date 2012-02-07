#import('dart:html');
#source('Job.dart');

class minirunner {

  minirunner() {
  }

  void run() {
    Job j1 = new Job ("job 1", new Date(2010, 3, 4, 12, 00, 00, 00));
    Job j2 = new Job ("job 2", new Date(2010, 3, 4, 12, 00, 00, 00));
    Job j3 = new Job ("job 3", new Date(2010, 3, 4, 12, 00, 00, 00));
    append ("Registered Jobs");
    for (Job j in [j1, j2, j3])
      {
      append (j.title + " " + j.nextExecution);
      };
      
     var url = "http://www.google.com";
      append ("connecting " + url);
      var request = new XMLHttpRequest ();
     request.open ("GET", url, false);
     append ("opened.");
     request.send ();
     append ("sent.");
     var res = request.responseText;
     
     append (res);
  }

  void append(String message) {
    // the HTML library defines a global "document" variable
    document.query('#status').innerHTML = document.query('#status').innerHTML  + message + "<br/>";
  }
}

void main() {
  new minirunner().run();
}
