import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
    }

    componentDidMount() {
        this.populateProductsData();
    }

    static async sellProduct(productid) {
        await fetch(`products/sellproduct?productid=${encodeURIComponent(productid)}`);
    }

    static renderProductsTable(products) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Stock</th>
                        <th>Sell</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product =>
                        <tr key={product.id}>
                            <td>{product.id ?? 'Id is missing'}</td>
                            <td>{product.name}</td>
                            <td>{product.price ?? 'Price is missing'}</td>
                            <td>{product.stock ?? 'Stock is missing'}</td>
                            <td>
                                <button className="btn btn-primary" onClick={() => FetchData.sellProduct(product.id)}>Sell one</button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderProductsTable(this.state.products);

        return (
            <div>
                <h1 id="tabelLabel" >Products</h1>
                {contents}
            </div>
        );
    }

    async populateProductsData() {
        const response = await fetch('products');
        const data = await response.json();
        this.setState({ products: data, loading: false });
    }
}
