using System;
using System.Collections.Generic;

namespace models
{
  public class Job
  {
    public int JobId { get; set; }

    //     [Key]
    //     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //     public int Id { get; set; }


    //     //JobQueue - M:1
    //     public int JobQueueId { get; set; }

    //     [ForeignKey(nameof(JobQueueId))]
    //     public JobQueue JobQueue { get; set; }

    //     // The flow is the workflow that this job will perform
    //     public virtual Flow Flow { get; set; }

    //     public string Error { get; set; }

    //     public string Warnings { get; set; }

    //     public DateTime? ExecuteAfter { get; private set; }
    //     public DateTime? LastUpdatedOn { get; private set; }
    //     public DateTime? QueuedOn { get; private set; }

    //     public DateTime? StartedOn { get; private set; }

    //     public JobStatus Status { get; private set; }

    //     public byte Priority { get; set; }

    //     public int? SubmittedBy { get; set; }

    //     public ICollection<JobProcessingError> JobProcessingErrors { get; set; }

  }

}
