create database controleDeEstoque
use controleDeEstoque

create table produto(
	idProduto int identity primary key,
	nome varchar(50) not null,
	descricao varchar(110),
	tipo varchar(20),
	preco_venda money not null
)

create table compra(
	id int primary key identity,
	data_compra date not null,
	quantidade int not null,
	preco_total money not null,
	codProduto int foreign key references produto(idProduto) not null,
	precoUnitario money
)


create table vendas(
	idVenda int primary key identity,
	codProduto int foreign key references produto(idProduto) not null,
	quantidade int not null,
	pagamento varchar(20),
	valorVenda money not null,
	dataVenda date,
	custo money
)
