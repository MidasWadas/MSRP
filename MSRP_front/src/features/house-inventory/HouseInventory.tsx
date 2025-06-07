import React, { useState, useEffect } from "react";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";

interface InventoryItem {
	id: number;
	name: string;
	quantity: number;
	category: string;
	location: string;
}

const HouseInventory: React.FC = () => {
	const [items, setItems] = useState<InventoryItem[]>([
		{
			id: 1,
			name: "Couch",
			quantity: 1,
			category: "Furniture",
			location: "Living Room",
		},
		{
			id: 2,
			name: "TV",
			quantity: 2,
			category: "Electronics",
			location: "Living Room",
		},
		{
			id: 3,
			name: "Bed",
			quantity: 3,
			category: "Furniture",
			location: "Bedroom",
		},
		{
			id: 4,
			name: "Refrigerator",
			quantity: 1,
			category: "Appliances",
			location: "Kitchen",
		},
	]);

	const [loading, setLoading] = useState(false);

	const onAddItem = () => {
		alert("Add Item clicked!");
	};

	const onRemoveItem = (id: number) => {
		setItems((prevItems) => prevItems.filter((item) => item.id !== id));
	};

	useEffect(() => {
		setLoading(true);
		setTimeout(() => {
			setLoading(false);
		}, 1000);
	}, []);

	if (loading) {
		return <div>Loading...</div>;
	}

	return (
		<div className="house-inventory">
			<div className="house-inventory-header">
				<MText text="House Inventory" as="h1" size="xl" weight="bold" />
				<MButton
					text="Add Item"
					onClick={onAddItem}
					variant="primary"
				/>
			</div>
			<ul className="house-inventory-list">
				{items.map((item) => (
					<li key={item.id} className="house-inventory-item">
						<MText text={item.name} as="span" size="md" />
						<MButton
							text="Remove"
							onClick={() => onRemoveItem(item.id)}
							variant="outlined"
							size="small"
						/>
					</li>
				))}
			</ul>
		</div>
	);
};

export default HouseInventory;
