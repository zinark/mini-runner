class Job {
  String title = "undefined";
  Date nextExecution;
  
  Job (String this.title, Date this.nextExecution);
  
  Iterable GetLogs ()
  {
    return ["log #1", "log #2"];
  }
}
