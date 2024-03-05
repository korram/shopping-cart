'use client'
import { Col, Row } from 'antd';
import Link from 'next/Link';
import { useState, useEffect } from "react";
import { listProduct } from "@/services/product-service";
import { insertCart, getCart } from "@/services/cart-service";
import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';
import { Avatar, Card, Button } from 'antd';
import { ShoppingCartOutlined, ShoppingOutlined } from '@ant-design/icons';
const { Meta } = Card;
function ProductList() {
    const [products, setProducts] = useState([]);

    const fetchData = async () => {
        const products = await listProduct();
        setProducts(products);
    }
    const addCart = async (product) => {
        if (product.stockAmount == 0) {
            alert('Out of stock');
            return;
        }
        const cart = await getCart(product.id);
        if (cart != null && cart.amount == product.stockAmount) {
            alert('ไม่สามารถเพิ่มจำนวนสินค้าได้');
            return;
            
        }
        await insertCart({ productId: product.id, amount: 1 });
        alert('เพิ่มสินค้าเข้าตะกร้าเรียบร้อยแล้ว');
    }


    useEffect(() => {
        fetchData();
    }, []);

    return (<div style={{ padding: '20px' }}>
        <Row>
            {products?.map((product) => {
                return (
                    <Card
                        hoverable
                        style={{
                            width: 240,
                        }}
                    >
                        <Meta description={product.productCode} title={`${product.productName}`} />
                        <Row><Col>{`ราคา ${product.unitPrice.toLocaleString(navigator.language, { minimumFractionDigits: 0 })} บาท`}</Col></Row>
                        <Row><Col>{`คงเหลือ ${product.stockAmount}`}</Col></Row>
                        <Row><Col span={12}>  <Button type='button' onClick={() => addCart(product)}>เพิ่มสินค้า<ShoppingCartOutlined /></Button></Col>
                            <Col span={12}>   <Button type='button'><Link href="./shoppingcart">สั่งซื้อ<ShoppingOutlined /></Link></Button></Col></Row>


                    </Card>
                )
            })}
        </Row>
    </div >);
}
export default ProductList;