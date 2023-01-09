import React, { useState, useEffect } from "react";
import { deleteProduct, getAllProductsFromDB } from "../../services/services";

export const ProductsReportRow = (props) => {
  const [AllProducts, setAllProducts] = useState([]);

  const getDB = async () => {
    let result = await getAllProductsFromDB();
    setAllProducts(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      {AllProducts.length > 0 ? (
        AllProducts.map((Product) => {
          let { Code, Name, Price, Units_In_Stock, BC_code, Campaign_code, Image } = Product;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{Name}</td>
                <td>{Price}$</td>
                <td>{Units_In_Stock}</td>
                <td>{BC_code}</td>
                <td>{Campaign_code}</td>
                <td>{Image}</td>
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no campaigns.</h1>
      )}
    </>
  );
};
