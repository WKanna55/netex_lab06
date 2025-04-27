-- =========================
-- ESTRUCTURA DE BASE DE DATOS
-- =========================

-- Tabla de usuarios
CREATE TABLE Usuarios (
    id_usuario SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    rol VARCHAR(20) CHECK (rol IN ('Estudiante', 'Profesor', 'Administrador')) NOT NULL
);

-- Tabla de estudiantes
CREATE TABLE Estudiantes (
    id_estudiante SERIAL PRIMARY KEY,
    id_usuario INT UNIQUE REFERENCES Usuarios(id_usuario),
    nombre VARCHAR(100) NOT NULL,
    edad INT NOT NULL,
    direccion VARCHAR(255),
    telefono VARCHAR(20),
    correo VARCHAR(100)
);

-- Tabla de profesores
CREATE TABLE Profesores (
    id_profesor SERIAL PRIMARY KEY,
    id_usuario INT UNIQUE REFERENCES Usuarios(id_usuario),
    nombre VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100),
    correo VARCHAR(100)
);

-- Tabla de cursos
CREATE TABLE Cursos (
    id_curso SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    creditos INT NOT NULL
);

-- Tabla de matrículas
CREATE TABLE Matriculas (
    id_matricula SERIAL PRIMARY KEY,
    id_estudiante INT REFERENCES Estudiantes(id_estudiante),
    id_curso INT REFERENCES Cursos(id_curso),
    semestre VARCHAR(20)
);

-- Tabla de evaluaciones
CREATE TABLE Evaluaciones (
    id_evaluacion SERIAL PRIMARY KEY,
    id_estudiante INT REFERENCES Estudiantes(id_estudiante),
    id_curso INT REFERENCES Cursos(id_curso),
    calificacion DECIMAL(5, 2),
    fecha DATE
);

-- Tabla de asistencias
CREATE TABLE Asistencias (
    id_asistencia SERIAL PRIMARY KEY,
    id_estudiante INT REFERENCES Estudiantes(id_estudiante),
    id_curso INT REFERENCES Cursos(id_curso),
    fecha DATE,
    estado VARCHAR(20) CHECK (estado IN ('Presente', 'Ausente', 'Justificada'))
);

-- Tabla de materias
CREATE TABLE Materias (
    id_materia SERIAL PRIMARY KEY,
    id_curso INT REFERENCES Cursos(id_curso),
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT
);

-- =========================
-- INSERCIÓN DE DATOS
-- =========================

-- Usuarios (2 estudiantes, 2 profesores - uno con rol admin)
INSERT INTO Usuarios (username, password, rol) VALUES
('juan123', 'pass123', 'Estudiante'),
('ana456', 'pass456', 'Estudiante'),
('carlosR', 'mathpass', 'Administrador'),
('martaD', 'historypass', 'Profesor');

-- Estudiantes
INSERT INTO Estudiantes (id_usuario, nombre, edad, direccion, telefono, correo) VALUES
(1, 'Juan Pérez', 20, 'Calle Ficticia 123', '987654321', 'juan.perez@mail.com'),
(2, 'Ana Gómez', 22, 'Avenida Siempre Viva 456', '998877665', 'ana.gomez@mail.com');

-- Profesores
INSERT INTO Profesores (id_usuario, nombre, especialidad, correo) VALUES
(3, 'Carlos Ramírez', 'Matemáticas', 'carlos.ramirez@mail.com'),
(4, 'Marta Díaz', 'Historia', 'marta.diaz@mail.com');

-- Cursos
INSERT INTO Cursos (nombre, descripcion, creditos) VALUES
('Matemáticas I', 'Curso introductorio a las matemáticas', 4),
('Historia Universal', 'Historia de los principales eventos a nivel mundial', 3);

-- Matrículas
INSERT INTO Matriculas (id_estudiante, id_curso, semestre) VALUES
(1, 1, '2025-1'),
(2, 2, '2025-1');

-- Evaluaciones
INSERT INTO Evaluaciones (id_estudiante, id_curso, calificacion, fecha) VALUES
(1, 1, 18.5, '2025-03-10'),
(2, 2, 15.0, '2025-03-12');

-- Asistencias
INSERT INTO Asistencias (id_estudiante, id_curso, fecha, estado) VALUES
(1, 1, '2025-03-10', 'Presente'),
(2, 2, '2025-03-12', 'Ausente');

-- Materias
INSERT INTO Materias (id_curso, nombre, descripcion) VALUES
(1, 'Algebra', 'Estudio de las estructuras algebraicas'),
(2, 'Geografía', 'Estudio de las formaciones geográficas del mundo');
