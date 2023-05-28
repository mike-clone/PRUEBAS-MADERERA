/*
Antes de ejecutar estas pruebas, asegúrate de:
(USUARIO: daniel@gmail.com) 
- Carrito Vacío
- Ninguna compra realizada

Solo esten registrado los usuarios cesar, omar, ximena, daniel, nistx

DELETE FROM DETALLE_VENTA
DELETE FROM VENTA
DELETE FROM USUARIO WHERE idUsuario > 5
*/

describe("Index", () => {
  it("Abrir Aplicación Correctamente", () => {
    cy.visitarURL("");
    cy.contains("Maderera");
  });
});

describe("Login", () => {
  beforeEach(() => {
    cy.visitarURL("/Home/Login");
  });
  Cypress.on("uncaught:exception", (err, runnable) => {
    return false;
  });

  it("Login Incorrecto", function () {
    cy.get("#valid_username").type("error@gmail.com");
    cy.get("#valid_password").type("error");
    cy.get(".btn").click();
    cy.get(".alert").should("contain", "user or password invalid");
  });

  it("Login Correcto", function () {
    cy.get("#valid_username").type("daniel@gmail.com");
    cy.get("#valid_password").type("123");
    cy.get(".btn").click();
    cy.contains("Mis compras");
  });

  it("Cerrar Sesión", function () {
    cy.logIn();
    cy.get(":nth-child(6) > a").click();
    cy.contains("LogIn");
  });
});

describe("Crear Usuario", () => {
  beforeEach(() => {
    cy.visitarURL("");
    cy.get(":nth-child(4) > .nav-link").click();
  });
  Cypress.on("uncaught:exception", (err, runnable) => {
    return false;
  });

  it("Registro Correcto", function () {
    cy.get("#nombre").type("Usuario", { force: true });
    cy.get("#username").type("Usuario#1", { force: true });
    cy.get("#inputEmail4").type("usuario@gmail.com", { force: true });
    cy.get("#inputPassword4").type("123", { force: true });
    cy.get("#ubigeo").select("140103", { force: true });
    cy.get(".btn").click({ force: true });
    cy.get("#valid_username").type("usuario@gmail.com");
    cy.get("#valid_password").type("123");
    cy.get(".btn").click();
    cy.get("ul > :nth-child(3) > a").should("contain", "Mis compras");
  });
  it("Registro Correo Existente", function () {
    cy.get("#nombre").type("Usuario", { force: true });
    cy.get("#username").type("Usuario#222", { force: true });
    cy.get("#inputEmail4").type("daniel@gmail.com", { force: true });
    cy.get("#inputPassword4").type("123", { force: true });
    cy.get("#ubigeo").select("140101", { force: true });
    cy.get(".btn").click();
    cy.get(".message-container > :nth-child(3)").should(
      "contain",
      "Violation of UNIQUE KEY constraint"
    );
  });

  it("Registro Incorrecto", function () {
    //Dejar campos faltantes
    cy.get("#nombre").type("error", { force: true });
    cy.get("#username").type("error", { force: true });
    cy.get("#inputPassword4").type("error", { force: true });
    cy.get(".btn").click();
    cy.get(":nth-child(3) > .invalid-feedback").should(
      "contain",
      "Please choose a Email."
    );
    cy.get(".col-md-3 > .invalid-feedback").should(
      "contain",
      "Please select a valid province."
    );
  });
});

describe("Productos", () => {
  beforeEach(() => {
    cy.visitarURL("/Home/Login");
    cy.logIn();
  });
  Cypress.on("uncaught:exception", (err, runnable) => {
    return false;
  });

  it("Buscar Producto", function () {
    cy.get('input[name="dato"]').type("Viga 8", { force: true });
    cy.get("#Bproducto > .btn").click({ force: true });
    cy.wait(1000);
    cy.get(":nth-child(2) > tr > :nth-child(2)").should("contain", "VIGA");
  });

  it("Agregar al Carrito", function () {
    //Producto id 10
    cy.get(":nth-child(10) > :nth-child(8) > .btn > .bi").click({
      force: true,
    });
    cy.wait(1000);
    //Producto id 20
    cy.get(":nth-child(20) > :nth-child(8) > .btn > .bi").click({
      force: true,
    });
    cy.wait(1000);
    //Buscar producto y agregarlo
    cy.get('input[name="dato"]').type("Viga 8", { force: true });
    cy.get("#Bproducto > .btn").click({ force: true });
    cy.wait(1000);
    cy.get(":nth-child(8) > .btn > .bi").click({
      force: true,
    });
    cy.wait(1000);
    //Mostrar Carrito
    cy.get(":nth-child(4) > a").click();
    cy.wait(1000);
    cy.get("tbody > :nth-child(1) > :nth-child(2)").should(
      "contain",
      "MANDANA"
    );
    cy.get("tbody > :nth-child(2) > :nth-child(2)").should(
      "contain",
      "VARA PAQUETE"
    );
    cy.get("tbody > :nth-child(3) > :nth-child(2)").should("contain", "VIGA");
  });

  it("Eliminar del Carrito", function () {
    cy.get(":nth-child(4) > a").click();
    cy.wait(1000);
    cy.get(":nth-child(3) > :nth-child(9) > .btn > .bi").click({ force: true });
    cy.get(".swal2-container").click();
    cy.get(".swal2-confirm").click();
    cy.get(".swal2-confirm").click();
    cy.get("table").find("tbody tr").should("have.length", 2);
  });
});

describe("Compra", () => {
  beforeEach(() => {
    cy.visitarURL("/Home/Login");
    cy.logIn();
    cy.get(":nth-child(4) > a").click();
    cy.wait(1000);
  });
  Cypress.on("uncaught:exception", (err, runnable) => {
    return false;
  });

  it("Realizar Pedido", function () {
    cy.get(".btn-success > .bi").click({ force: true });
    cy.wait(1000);
    //Comprobamos que haya una compra
    cy.get("table").find("tbody tr").should("have.length", 1);
    //Ingresamos al detalle
    cy.get(":nth-child(1) > :nth-child(5) > .btn > a").click({ force: true });
    cy.wait(1000);
    //Comprobamos que esten los productos y el precio correcto
    cy.get("tbody > :nth-child(1) > :nth-child(2)").should(
      "contain",
      "MANDANA"
    );
    cy.get("tbody > :nth-child(2) > :nth-child(2)").should(
      "contain",
      "VARA PAQUETE"
    );
    cy.get(":nth-child(8) > .container > :nth-child(2)").should(
      "contain",
      "17.8"
    );
    //Revisamos que el carrito este vacío
    cy.get(":nth-child(4) > a").click();
    cy.wait(1000);
    cy.get("table").find("tbody tr").should("have.length", 0);
  });
});

describe("Sin Permisos", () => {
  it("Redirección de Página", () => {
    cy.visitarURL("/Home/Login");
    cy.logIn();
    cy.visitarURL("/Compra/ListarTodasLasCompras");
    cy.get(".alert > p").should(
      "contain",
      "opps!! usted no tiene los permisos suficientes para ver este lugar"
    );
  });
});
