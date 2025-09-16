CREATE TABLE
  fornecedor (
    id_for INT NOT NULL AUTO_INCREMENT,
    nome_for VARCHAR(255) NOT NULL,
    PRIMARY KEY (id_for)
  );

CREATE TABLE
  produto (
    id_pro INT NOT NULL AUTO_INCREMENT,
    id_for_fk INT NULL,
    nome_pro VARCHAR(255) NOT NULL,
    descricao_pro TEXT NULL,
    quantidade_pro INT NOT NULL,
    preco_pro DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_pro),
    FOREIGN KEY (id_for_fk) REFERENCES fornecedor (id_for)
  );

-- Inserindo fornecedores
INSERT INTO
  fornecedor (nome_for)
VALUES
  ('Fornecedor Alpha'),
  ('Fornecedor Beta'),
  ('Fornecedor Gamma'),
  ('Fornecedor Delta');

-- Inserindo produtos vinculados aos fornecedores
INSERT INTO
  produto (
    id_for_fk,
    nome_pro,
    descricao_pro,
    quantidade_pro,
    preco_pro
  )
VALUES
  (
    1,
    'Notebook X',
    'Notebook de alto desempenho com 16GB RAM e SSD 512GB',
    10,
    4500.00
  ),
  (
    1,
    'Mouse Óptico',
    'Mouse com fio, 1200 DPI',
    50,
    45.90
  ),
  (
    2,
    'Smartphone Y',
    'Smartphone 6.5 polegadas, 128GB',
    20,
    2100.00
  ),
  (
    2,
    'Carregador Rápido',
    'Carregador USB-C 25W',
    100,
    89.90
  ),
  (
    3,
    'Cadeira Gamer',
    'Cadeira ergonômica ajustável',
    15,
    1250.00
  ),
  (
    3,
    'Mesa de Escritório',
    'Mesa em L com suporte para monitor',
    8,
    980.00
  ),
  (
    4,
    'Monitor 27"',
    'Monitor LED Full HD 27 polegadas',
    12,
    1150.00
  ),
  (
    4,
    'Teclado Mecânico',
    'Teclado RGB switch blue',
    30,
    350.00
  );