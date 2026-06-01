# SistemaAquaFresh 

Sistema de gestión de ventas para distribuidora de agua, desarrollado en C# Windows Forms.

## Especificaciones del sistema
- **Lenguaje:** C# (.NET Framework 4.7.2)
- **Tipo:** Aplicación de escritorio Windows Forms
- **Arquitectura:** MVC simplificado (Entidades / Controlador / Formularios)

### Clases principales
| Clase | Descripción |
|-------|-------------|
| `Persona` | Clase base con datos personales (cédula, nombre, apellido, dirección, teléfono) |
| `Cliente` | Hereda de Persona. Incluye tipo de cliente, tipo de pago y datos de la transacción |
| `Producto` | Representa los productos del catálogo (bidón 20L, galón 5L, botella 500ml) |
| `Venta_Controler` | Controlador estático que gestiona listas de clientes y productos, y procesa ventas |

### Formularios
| Formulario | Función |
|-----------|---------|
| `frmPrincipal` | Menú principal MDI |
| `frmVentas` | Registro y procesamiento de ventas |
| `frmReportes` | Generación de reportes en PDF |

## Flujo de trabajo (Ramas)
| Rama | Función |
|------|---------|
| `master` | Versión estable y final del sistema |
| `develop` | Integración de cambios antes de pasar a master |
| `feature/producto` | Mejora de validaciones en la clase Producto |

## Pipeline CI
El pipeline se activa automáticamente en cada push o Pull Request hacia master o develop.
Compila el proyecto con MSBuild en Windows para verificar que no haya errores.

## Autor
Eduardo Endara 
Alejandro Jimenez
