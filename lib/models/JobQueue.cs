using System;
using System.Collections.Generic;

namespace models
{
  public enum QueuePurpose
  {
    None,
    Processing,
    Retry,
    Succeeded,
    Failed
  }
  public class JobQueue
  {
    public int JobQueueId { get; set; }
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // public int Id { get; set; }

    public virtual Agent Agent { get; set; }

    public QueuePurpose Purpose { get; set; }

    // public ICollection<Job> Jobs { get; set; }

  }

}
