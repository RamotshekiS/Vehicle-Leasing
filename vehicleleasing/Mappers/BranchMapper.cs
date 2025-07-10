using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vehicleleasing.Dtos.Branch;
using vehicleleasing.Dtos.Branch;
using vehicleleasing.Models;

namespace vehicleleasing.Mappers
{
    public static class BranchMapper
    {
        public static BranchDto ToBranchDto(this Branch branch)
        {
            return new BranchDto
            {
                Id = branch.Id,
                branchName = branch.branchName,
                location = branch.location
                //Manager = branch.Manager
            };
        }

        public static Branch ToBranchFromCreateDto(this CreateBranchDto dto)
        {
            return new Branch
            {
                branchName = dto.branchName,
                location = dto.location
                //Manager = dto.Manager
            };
        }
    }
}