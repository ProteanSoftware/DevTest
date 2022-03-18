using System;
using DeveloperTest.DTO.Customer;

namespace DeveloperTest.DTO.Job;

public record JobDto(int JobId, string Engineer, DateTime When, CustomerDto Customer);