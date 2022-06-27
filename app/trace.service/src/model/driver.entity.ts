import { Column, Entity, JoinColumn, OneToOne, ManyToOne } from 'typeorm';
import { BaseTaggedEntity } from './base.tagged.entity';
import { DriverGroup } from './driver.group.entity';
import { User } from './user.entity';

@Entity({ name: 'drivers' })
export class Driver extends BaseTaggedEntity {
  @OneToOne(() => User)
  @JoinColumn()
  public user: User;

  @ManyToOne(() => DriverGroup, (group) => group.driver)
  @JoinColumn()
  public group: DriverGroup;

  @Column()
  public identifier: string;

  @Column({ type: 'varchar', length: 128, nullable: true })
  public barcode: string;

  @Column({ type: 'timestamptz', nullable: true })
  public employed!: Date;

  @Column({ type: 'timestamptz', nullable: true })
  public dismissed!: Date;
}
