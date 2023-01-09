import React from "react";
import "./AllProductsReportStyle.css";

export function AllProductsReport(props) {
  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">ID</th>
          <th scope="col">Name</th>
          <th scope="col">Units In Stoke</th>
          <th scope="col">Company</th>
          <th scope="col">Campaign</th>
          <th scope="col">Price</th>
        </tr>
      </thead>
      <tbody className="table-group-divider">
        <tr>
          <th scope="row">?</th>
          <td>?</td>
          <td>?</td>
          <td>?</td>
          <td>?</td>
          <td>?</td>
        </tr>
      </tbody>
    </table>
  );
}
