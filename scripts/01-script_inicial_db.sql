/*
DROP TABLE TSeg_Clientes_Polizas;
DROP TABLE TSeg_Polizas_Tipo_Cubrimiento;
DROP TABLE TSeg_Polizas;
DROP TABLE TSeg_Tipo_Cubrimiento;
DROP TABLE TSeg_Clientes;
DROP TABLE TSeg_Usuarios;
*/

CREATE TABLE TSeg_Usuarios(
   id bigint NOT NULL IDENTITY PRIMARY KEY,   
   usuario varchar(20) NOT NULL,
   contrasena varchar(128) NOT NULL,  
   estado smallint NOT NULL,   
   UNIQUE(usuario) 
);

CREATE TABLE TSeg_Clientes(
   id bigint NOT NULL IDENTITY PRIMARY KEY,
   tipo_identificacion varchar(6) NOT NULL,
   identificacion varchar(100) NOT NULL,
   nombres varchar(50) NOT NULL,
   apellidos  varchar(50) NOT NULL,
   telefono  varchar(12),
   direccion varchar(30),
   UNIQUE(tipo_identificacion, identificacion)	
);

CREATE TABLE TSeg_Tipo_Cubrimiento(
   id bigint NOT NULL IDENTITY PRIMARY KEY,  
   nombre varchar(50) NOT NULL   
);

CREATE TABLE TSeg_Polizas(
   id bigint NOT NULL IDENTITY PRIMARY KEY,  
   nombre varchar(50) NOT NULL,     
   descripcion varchar(200),  
   UNIQUE(nombre) 
);

CREATE TABLE TSeg_Polizas_Tipo_Cubrimiento(
   id_poliza bigint,
   id_tipo_cubrimiento bigint,  
   FOREIGN KEY (id_poliza) REFERENCES TSeg_Polizas(id),   
   FOREIGN KEY (id_tipo_cubrimiento) REFERENCES TSeg_Tipo_Cubrimiento(id),   
   PRIMARY KEY (id_poliza, id_tipo_cubrimiento)
);

CREATE TABLE TSeg_Clientes_Polizas(
   id_cliente bigint,
   id_poliza bigint,  
   fecha_inicio datetime NOT NULL, 
   meses_cobertura smallint,
   cobertura decimal,       
   precio decimal,
   riesgo varchar(10),
   FOREIGN KEY (id_cliente) REFERENCES TSeg_Clientes(id),   
   FOREIGN KEY (id_poliza) REFERENCES TSeg_Polizas(id),   
   PRIMARY KEY (id_cliente, id_poliza)
);
