using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusTypeFactory
{
    public static StatusTypeEntity? Create(StatusTypeForm form) => form == null ? null : new()
    {
        StatusName = form.StatusName,
    };


    public static StatusType? Create(StatusTypeEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName,
    };
}
