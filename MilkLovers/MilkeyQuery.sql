CREATE TABLE reg_clients (
  customerId INTEGER PRIMARY KEY, 
  registrationDateTime DATE, 
  name TEXT);
INSERT INTO reg_clients (customerId, registrationDateTime, name)
VALUES (1, '2016-01-13', 'John'), 
       (2, '2016-01-13', 'Unknown Chupakabra'),
       (3, '2016-01-13', 'Beauty Joe');
       
CREATE TABLE purchases (
  customerId INTEGER, 
  purchaseDateTime DATE, 
  productName  TEXT,
  FOREIGN KEY (customerId) REFERENCES reg_clients(customerId));
INSERT INTO purchases (customerId, purchaseDateTime, productName)
VALUES (1, '2016-05-13', 'milk'),
       (1, '2016-05-19', 'water'),
       (1, '2016-05-3', 'sour cream'),
       (2, '2016-05-23', 'milk'),
       (2, '2016-05-6', 'chocolate'),
       (3, '2016-04-19', 'milk'),
       (3, '2016-04-30', 'milk'),
       (3, '2016-04-28', 'sour cream');
      

SELECT DISTINCT name
FROM reg_clients
LEFT JOIN purchases ON
  reg_clients.customerId = purchases.customerId
WHERE purchaseDateTime > DATE_SUB(CURRENT_DATE, INTERVAL 1 MONTH)
  AND productName = 'milk'
  AND reg_clients.customerId NOT IN 
(SELECT DISTINCT customerId
FROM purchases
WHERE purchaseDateTime > DATE_SUB(CURRENT_DATE, INTERVAL 1 MONTH)
  AND productName = 'sour cream');