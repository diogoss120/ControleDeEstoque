use controleDeEstoque;


create table produto(
	idProduto integer auto_increment primary key,
	nome varchar(50) not null,
	descricao varchar(110),
	tipo varchar(20),
	preco_venda double not null
);

create table compra(
	id integer auto_increment primary key,
	data_compra date not null,
	quantidade int not null,
	preco_total double not null,
	codProduto int not null,
	precoUnitario double,
        foreign key(codProduto) references produto(idProduto) 
);


create table vendas(
	idVenda integer auto_increment primary key,
	codProduto int not null,
	quantidade int not null,
	pagamento varchar(20),
	valorVenda double not null,
	dataVenda date,
	custo double,
	foreign key (codProduto) references produto(idProduto)
);