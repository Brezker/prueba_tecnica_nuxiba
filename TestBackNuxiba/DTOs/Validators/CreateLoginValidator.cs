using System;
using System.ComponentModel.DataAnnotations;

namespace TestBackNuxiba.DTOs.Validators
{
    // Used by UpdateLoginDto.fecha. On create the date is assigned by the server (DateTime.Now).
    public class CreateLoginValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime fecha)
            {
                // Evita registrar inicios de sesión en el futuro (damos 1 minuto de tolerancia por retrasos de red)
                if (fecha > DateTime.Now.AddMinutes(1))
                {
                    return new ValidationResult("La fecha del evento no puede estar en el futuro.");
                }

                // Evita fechas inválidas o por defecto (como el año 0001)
                if (fecha < new DateTime(2000, 1, 1))
                {
                    return new ValidationResult("La fecha del evento no es una fecha válida para el sistema.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("El formato de la fecha es incorrecto o el campo está vacío.");
        }

    }
}
