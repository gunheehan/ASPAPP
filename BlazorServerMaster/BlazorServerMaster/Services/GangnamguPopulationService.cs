using BlazorServerMaster.Context;
using BlazorServerMaster.Entities;
using BlazorServerMaster.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerMaster.Services;

public class GangnamguPopulationService : IDatabase<GangnamguPopulation>
{
    private readonly MyDbContext context;


    public GangnamguPopulationService(MyDbContext context)
    {
        this.context = context;
    }

    public async Task<List<GangnamguPopulation>>? GetAsync()
    {
        return await context?.GangnamguPopulations.ToListAsync();
    }

    public GangnamguPopulation GetDetail(int? id)
    {
        var validData = context.GangnamguPopulations.FirstOrDefault(x => x.Id == id);

        if (validData != null)
            return validData;

        throw new NullReferenceException();
    }

    public void Create(GangnamguPopulation entity)
    {
        if (context.GangnamguPopulations == null)
        {
            throw new NullReferenceException();
        }

        context.GangnamguPopulations.Add(entity);
        context.SaveChanges();
    }

    public void Update(int? id, GangnamguPopulation entity)
    {
        var validData = context.GangnamguPopulations.Find(id);
        if (validData != null)
        {
            context.GangnamguPopulations.Update(entity);
            context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Delete(int? id)
    {
        var validData = context.GangnamguPopulations.Find(id);
        if (validData != null)
        {
            context.GangnamguPopulations.Remove(validData);
            context.SaveChanges();
        }
    }
}