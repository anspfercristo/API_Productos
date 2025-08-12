
# INSTRUCCIONES DE USO PARA API_PRODUCTOS: CONSULTA DE ENDPOINTS

---

## 1) ABRIR CONSOLA DE POWER SHELL DE WINDOWS

1. **Usando el menú Inicio:**
   - Haz clic en el botón **Inicio** (icono de Windows).
   - Busca `PowerShell`.
   - Presiona **Enter** o haz clic en **Windows PowerShell**.

2. **Usando el diálogo Ejecutar: RECOMENDADO**
   - Presiona las teclas **Windows + R** al mismo tiempo.
   - En la ventana que aparece, escribe `powershell`.
   - Presiona **Enter**.

---

## 2) EJECUTAR PEDIDOS A LA API MEDIANTE COMANDOS

### 2.1) Búsqueda de producto por ID

- **Request:** Comando para buscar el producto con ID = 1  
```
curl.exe -k -H "X-API-KEY: apiproductskey824673195" "https://apiproduct-d3adhmbke0hza5gp.chilecentral-01.azurewebsites.net/api/Products/GetProductByID?id=1"
```

- **Response:** JSON con información del producto y estado de error.  
```json
{
  "error": false,
  "errorMsg": "",
  "product": {
    "id": 1,
    "name": "Auriculares Bluetooth Marca 1",
    "description": "Auriculares inalámbricos con cancelación de ruido",
    "price": 79000.00,
    "imageUrl": "https://ejemplo.com/img/auricular1.jpg",
    "rating": 4.4,
    "specs": {
      "batteryHours": 24,
      "color": "Negro",
      "connectivity": "Bluetooth 5.2"
    }
  }
}
```

---

### 2.2) Búsqueda de productos por IDs

- **Request:** Comando para buscar los productos con IDs 1 y 2  
```
curl.exe -k -X POST `
  -H "Content-Type: application/json" `
  -H "X-API-KEY: apiproductskey824673195" `
  -d "[1,2]" `
  "https://apiproduct-d3adhmbke0hza5gp.chilecentral-01.azurewebsites.net/api/Products/GetListProductByIDs"
```

- **Response:** JSON con información de los productos 1 y 2 y estado de error.  
```json
{
  "error": false,
  "errorMsg": "",
  "products": [
    {
      "id": 1,
      "name": "Auriculares Bluetooth Marca 1",
      "description": "Auriculares inalámbricos con cancelación de ruido",
      "price": 79000.00,
      "imageUrl": "https://ejemplo.com/img/auricular1.jpg",
      "rating": 4.4,
      "specs": {
        "batteryHours": 24,
        "color": "Negro",
        "connectivity": "Bluetooth 5.2"
      }
    },
    {
      "id": 2,
      "name": "Auriculares Bluetooth Marca 2",
      "description": "Auriculares con micrófono integrado",
      "price": 75000.00,
      "imageUrl": "https://ejemplo.com/img/auricular2.jpg",
      "rating": 4,
      "specs": {
        "batteryHours": 18,
        "color": "Blanco",
        "connectivity": "Bluetooth 5.0"
      }
    }
  ]
}
```

---

## OTRAS OPCIONES

- Si se cambia la clave `X-API-KEY` por una incorrecta, la respuesta esperada es:  
```json
{
  "title": "Unauthorized",
  "status": 401
}
```

- Si se envía un ID inexistente, la respuesta esperada es:  
```json
{
  "error": false,
  "errorMsg": "",
  "product": null
}
```

---

## NOTAS

- Se proporciona solución del proyecto, creada en **.NET 8** con **Visual Studio 2022**.  
- Se puede usar para revisar estructura, casos de prueba, pruebas en localhost, etc.
- Para mas informacion : https://apiproduct-d3adhmbke0hza5gp.chilecentral-01.azurewebsites.net/swagger/index.html