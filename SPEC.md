# SPEC.md — Especificación del Sistema AquaFresh

## 1. Descripción del problema
La empresa AquaFresh gestiona sus ventas, clientes y productos de forma manual
mediante pizarras y papel, lo que genera pérdida de información, descuadres
financieros y falta de reportes para la toma de decisiones.

## 2. Objetivo del sistema
Desarrollar una aplicación de escritorio en C# Windows Forms que automatice
el registro de clientes, productos y ventas, eliminando los procesos manuales.

## 3. Entidades del dominio

### Persona (clase base)
| Atributo | Tipo | Regla |
|----------|------|-------|
| Cedula | string | No puede estar vacía |
| Nombre | string | No puede estar vacío |
| Apellido | string | No puede estar vacío |
| Direccion | string | Opcional |
| Telefono | string | Opcional |

### Cliente (hereda de Persona)
| Atributo | Tipo | Regla |
|----------|------|-------|
| TipoCliente | string | Debe ser "Regular" o "Mayorista" |
| TipoPago | string | Debe ser "Efectivo" o "Transferencia" |

### Producto
| Atributo | Tipo | Regla |
|----------|------|-------|
| Id_producto | int | Autogenerado, único |
| Nombre | string | No puede estar vacío |
| Tipo_envase | string | Bidón 20L / Galón 5L / Botella 500ml |
| Precio_unitario | decimal | No puede ser negativo |

### Venta_Controler (controlador)
| Responsabilidad | Descripción |
|-----------------|-------------|
| Gestionar clientes | Agregar, listar y buscar clientes |
| Gestionar productos | Agregar, listar y buscar productos |
| Procesar ventas | Calcular totales y registrar transacciones |

## 4. Casos de uso

### CU-01: Registrar venta
- **Actor:** Cajero
- **Precondición:** El cliente y el producto deben existir en el sistema
- **Flujo:** Seleccionar cliente → seleccionar producto → ingresar cantidad → calcular total → confirmar venta
- **Postcondición:** La venta queda registrada y el stock se actualiza

### CU-02: Registrar cliente
- **Actor:** Cajero
- **Precondición:** La cédula no debe existir en el sistema
- **Flujo:** Ingresar datos personales → seleccionar tipo de cliente → guardar
- **Postcondición:** El cliente queda disponible para futuras ventas

### CU-03: Generar reporte
- **Actor:** Administrador
- **Precondición:** Debe existir al menos una venta registrada
- **Flujo:** Seleccionar rango de fechas → generar reporte → exportar PDF
- **Postcondición:** El reporte queda disponible para descarga

## 5. Arquitectura del sistema
- **Lenguaje:** C# .NET Framework 4.7.2
- **Tipo:** Aplicación de escritorio Windows Forms
- **Patrón:** MVC simplificado (Entidades / Controlador / Formularios)
- **Metodología:** Spec Driven Development

## 6. Flujo de trabajo (GitFlow)
| Rama | Propósito |
|------|-----------|
| master | Código estable y final |
| develop | Integración de cambios |
| feature/* | Desarrollo de funcionalidades |

## 7. Pipeline CI
Automatización con GitHub Actions que verifica la compilación del proyecto
en cada push o Pull Request hacia master o develop.

## Autores
- Luis Eduardo Endara Salinas
- Alejandro Josue Jiménez Correa

**Universidad Técnica de Machala — 2026**
