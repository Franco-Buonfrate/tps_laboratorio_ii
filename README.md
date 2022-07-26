# Correcciones:

TP1-
Convierte mal a binario
La validación de los números se debería hacer en Operando, no en la vista
Operando(string strNumero) no hace lo pedido. no utiliza la propiedad
double.Parse(strNumero) muy permeable a fallos
ValidarOperando tiene código redundante (TryParse ya carga retorno en 0 si no puede convertir)

TP3-
Ojo los nombres de las carpetas de los TPs, cumplir con classroom. Gestión pinturería - hay algunos
conceptos que están raros. Cliente no tiene sentido que sea genérico, tenes un solo tipo de clientes.
Las excepciones están bien, pero esa logica debe estar en entidades, no en los formularios. (Debe
haber validaciones en ambas capas, eso sí está bien). Y ojo, porque tenes excepciones sin usar. Es
arreglar eso y estás, el resto está bien!

TP4-
Gestión pinturería - hay algunos conceptos que siguen estando raros. Cliente no tiene sentido que
herede de persona, si no tenes ninguna otra herencia. De persona podría derivar empleado(?) y
cliente, pero solo cliente no tiene sentido, ojo con eso. Se piden Eventos propios, no los que
ofrecen los forms. Queda eso y estas!
