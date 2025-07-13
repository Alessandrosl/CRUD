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
INSERT INTO Funcionarios (_Nome, _CPF, _DataNascimento, _Endereco, _Telefone, _Sexo) VALUES 
('Alice Mendes', '11122233344', '1989-07-20', 'Rua K-1, 101, Nova Brasília, Ji-Paraná - RO', '69981234567', 'F'),
('Bernardo Santos', '22233344455', '1993-03-12', 'Avenida Ji-Paraná, 202, Centro, Ji-Paraná - RO', '69982345678', 'M'),
('Cecília Oliveira', '33344455566', '1980-11-05', 'Rua T-15, 303, Urupá, Ji-Paraná - RO', '69983456789', 'F'),
('Diego Costa', '44455566677', '1975-09-28', 'Alameda Rio Branco, 404, Dom Bosco, Ji-Paraná - RO', '69984567890', 'M'),
('Eduarda Pereira', '55566677788', '1995-01-18', 'Rua K-5, 505, Vila Jotão, Ji-Paraná - RO', '69985678901', 'F'),
('Fábio Lima', '66677788899', '1982-04-01', 'Avenida Transcontinental, 606, Nova Brasília, Ji-Paraná - RO', '69986789012', 'M'),
('Giovana Rocha', '77788899900', '1990-06-25', 'Rua T-20, 707, Primavera, Ji-Paraná - RO', '69987890123', 'F'),
('Heitor Almeida', '88899900011', '1978-02-14', 'Rua Dom Pedro II, 808, JK, Ji-Paraná - RO', '69988901234', 'M'),
('Isabela Silva', '99900011122', '1997-10-30', 'Travessa da Paz, 909, Orleans, Ji-Paraná - RO', '69989012345', 'F'),
('Júlio César Souza', '00011122233', '1984-08-09', 'Rua K-0, 1010, Centro, Ji-Paraná - RO', '69990123456', 'M');