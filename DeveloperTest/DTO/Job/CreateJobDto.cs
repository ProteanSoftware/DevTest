using System;

namespace DeveloperTest.DTO.Job;

public record CreateJobDto(string Engineer, DateTime When, int CustomerId);