using CleanArchitecture.Domain.Abstractions;
namespace  CleanArchitecture.Domain.Vehiculos.Specifications;

public class VehiculoPaginacionSpecification
: BaseSpecification<Vehiculo, VehiculoId>{
    public VehiculoPaginacionSpecification(
        string sort, 
        int pageIndex,
        int pageSize,
        string search
        ) :base(
            x => string.IsNullOrEmpty(search) || x.Modelo == new Modelo(search)
        )
    {
        ApplyPading( pageSize*(pageIndex-1), pageSize);

        if(!string.IsNullOrEmpty(sort)){

            switch (sort){
                case "modeloAsc": AddOrderBy(p=>p.Modelo!);break;
                case "modeloDesc": AddOrderByDescending(p=>p.Modelo!);break;
                default: AddOrderBy(p=>p.FechaUltimaAlquiler!);break;

            }
        }else{
            AddOrderBy(p=>p.FechaUltimaAlquiler!);
        }
        
    }
}