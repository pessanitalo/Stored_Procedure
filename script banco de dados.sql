use consultasSQL;

alter table Pessoas drop column DataNascimento;
alter table Pessoas add DataNascimento date;

insert into Enderecos values ('rua vuarame','03574100','jardim santa maria',363,'sp');
insert into Enderecos values ('rua vuarame','03574100','jardim santa maria',361,'sp');
insert into Enderecos values ('rua vuarame','03574100','jardim santa maria',360,'sp');
insert into Enderecos values ('rua açai','03574000','jardim santa maria',567,'sp');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 557, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 551, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 552, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 553, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 554, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 555, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 556, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 558, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 541, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 542, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 543, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 544, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 545, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 546, 'são paulo');
insert into Enderecos values ('rua açai', 03574000, 'jardim santa maria', 548, 'são paulo');

insert into Pessoas values ( 'bruna leticia', 23024189808, 2, '1987-04-28');
insert into Pessoas values ( 'ricardo alves', 23024189801, 3, '1987-01-28');
insert into Pessoas values ( 'evandro guedes', 23024189802, 4, '1987-02-28');
insert into Pessoas values ( 'paulo souza', 23024189803, 5, '1987-03-28');
insert into Pessoas values ( 'ricardo demetrio', 23024189804, 6, '1987-04-03');
insert into Pessoas values ( 'thais souza', 23024189805, 7, '1987-05-02');
insert into Pessoas values ( 'diogo nogueira', 23024189806, 8, '1987-06-01');
insert into Pessoas values ( 'paulo francisco', 23024189807, 9, '1987-07-28');
insert into Pessoas values ( 'tiago francisco', 23024169808, 10, '1987-08-25');
insert into Pessoas values ( 'leandro dos santos', 23024189809, 11, '1987-09-24');
insert into Pessoas values ( 'peitro silva', 23024189810, 12, '1987-10-23');
insert into Pessoas values ( 'eduardo silva', 23024189811, 13, '1987-11-22');
insert into Pessoas values ( 'matheus silva', 23024189812, 14, '1987-12-21');
insert into Pessoas values ( 'diego bruno', 23024189813, 15, '1987-03-25');
insert into Pessoas values ( 'ana duimoulin', 23024189814, 16, '1987-05-26');
insert into Pessoas values ( 'pedro santos', 23024189815, 17, '1987-06-25');
insert into Pessoas values ( 'bruna roberta', 23024189808, 2, '1987-04-28');
insert into Pessoas values ( 'bruno roberto', 23024189808, 2, '1987-04-30');

create procedure p_ListaPessoas as
select * from dbo.Pessoas

exec p_ListaPessoas

create procedure PesquisarPessoaNome (@Nome nvarchar(50)) AS select * from dbo.Pessoas where Nome = @Nome
exec PesquisarPessoaNome @Nome = 'ana duimoulin'

create procedure BuscaId (@ID INT) AS select * from dbo.Pessoas where Id = @ID
exec BuscaId 2

CREATE PROCEDURE p_numeros
    @min AS INT,
    @max AS INT
AS
BEGIN
    SELECT *
    FROM Enderecos
    WHERE Numero > @min AND Numero < @max
end

exec p_numeros @min = 360, @max = 541

create procedure onenumber (@numero int) as select * from Enderecos where Numero = @numero

exec onenumber 360