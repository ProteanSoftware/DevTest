using DeveloperTest.Exceptions.Base;

namespace DeveloperTest.Exceptions;

public class JobNotFoundException : NotFoundException
{
    public JobNotFoundException(int jobId) 
        : base($"Job with id {jobId} doesn't exits.")
    { }
}