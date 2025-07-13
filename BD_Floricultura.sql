CREATE DATABASE IF NOT EXISTS BD_Floricultura;
-- drop database BD_Floricultura;
USE BD_Floricultura;

CREATE TABLE IF NOT EXISTS Funcionarios (
    _Id_Funcionarios INT PRIMARY KEY AUTO_INCREMENT,
    _Nome VARCHAR(100),
    _CPF VARCHAR(11) UNIQUE,
    _DataNascimento DATE,
    _Endereco VARCHAR(300),    
    _Telefone VARCHAR(11),
    _Sexo VARCHAR(1)
);

Select * from Funcionarios;