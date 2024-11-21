using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Vehiculos.Specifications;

public class VehiculoPaginacionCountingSpecification
:BaseSpecification<Vehiculo, VehiculoId>
{
    public VehiculoPaginacionCountingSpecification(string search) :
    base(
        x=>string.IsNullOrEmpty(search) || x.Modelo == new Modelo(search)
    )
    {
        
    }
    
}